using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[30000];
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
        PancakeSort(copy);
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }

    timeList.Remove(timeList.Max());

    var averageTime = timeList.ToArray().Sum() / 5;
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();
    
    Console.WriteLine(arr.Length);
    Console.WriteLine(averageTime);
    Array.Resize(ref arr, arr.Length - 300);
}

Helper.SaveResults(results);

static void Flip(int[] arr, int i)
{
    int start = 0;
    while (start < i)
    {
        (arr[start], arr[i]) = (arr[i], arr[start]);
        start++;
        i--;
    }
}
static int FindMax(int[] arr, int n)
{
    int mi, i;
    for (mi = 0, i = 0; i < n; ++i)
        if (arr[i] > arr[mi])
            mi = i;
    return mi;
}
static void PancakeSort(int[] arr)
{
    for (int currSize = arr.Length; currSize > 1; --currSize)
    {
        int mi = FindMax(arr, currSize);
        if (mi != currSize - 1)
        {
            Flip(arr, mi);
            Flip(arr, currSize - 1);
        }
    }
}

