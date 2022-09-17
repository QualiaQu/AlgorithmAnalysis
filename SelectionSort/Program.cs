using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[2000];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 100);
}
string results = "Объём данных;Время (миллисекунды)\n";
while (arr.Length != 0)
{
    List<double> timeList = new List<double>();
    for (int k = 1; k <= 20; k++)
    {
        int[] copy = new int[arr.Length];
        arr.CopyTo(copy, 0);
        stopwatch.Restart();
        SelectionSort(copy);
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }

    Console.WriteLine("------------------------------------------\n");
    Console.WriteLine($"объём данных{arr.Length}");

    foreach (var i in timeList)
    {
        Console.WriteLine(i);
    }

    var clearedList = Helper.TimeListCleaning(timeList);

    int count = 0;
    foreach (var i in clearedList)
    {
        if (i != 0)
        {
            count++;
        }
    }
    var averageTime = timeList.ToArray().Sum();
    averageTime /= count;
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    Array.Resize(ref arr, arr.Length - 20);
    timeList.Clear();
    Console.WriteLine("------------------------------------------\n");
    Console.WriteLine($"объём данных{arr.Length}");
    foreach (var i in timeList)
    {
        Console.WriteLine(i);
    }

}

Helper.SaveResults(results);

static void SelectionSort(int[] arr)
{
    for (int i = 0; i < arr.Length - 1; i++)
    {
        int min = i;
        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[j] < arr[min])
            {
                min = j;
            }
        }
        int temp = arr[min];
        arr[min] = arr[i];
        arr[i] = temp;
    }
}