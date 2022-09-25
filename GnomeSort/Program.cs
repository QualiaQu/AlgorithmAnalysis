using System.Diagnostics;
using HelperLibrary;


Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[50000];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 100);
}
string results = "Объём данных;Время (миллисекунды)\n";
while (arr.Length != 0)
{
    List<double> timeList = new List<double>();
    for (int k = 1; k <= 6; k++)
    {
        int[] copy = new int[arr.Length];
        arr.CopyTo(copy, 0);
        stopwatch.Restart();
        GnomeSort(copy);
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }

    timeList.Remove(timeList.Max());
    
    var averageTime = timeList.ToArray().Sum() / 5;
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();


    
    
    Array.Resize(ref arr, arr.Length - 1000);
}

Helper.SaveResults(results);

static void GnomeSort(int[] numbers)
{
    int index = 1;
    int nextIndex = index + 1;
    while (index < numbers.Length)
    {
        if (numbers[index - 1] < numbers[index])
        {
            index = nextIndex;
            nextIndex++;
        }
        else
        {
            (numbers[index - 1], numbers[index]) = (numbers[index], numbers[index - 1]);
            index--;
            if (index == 0)
            {
                index = nextIndex;
                nextIndex++;
            }
        }
    }
}