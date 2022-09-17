using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[10000];
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
        double mul = 1;
        stopwatch.Restart();
        foreach (var t in arr)
        {
            mul *= t;
        }
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
    Array.Resize(ref arr, arr.Length - 100);
    timeList.Clear();
    Console.WriteLine("------------------------------------------\n");
    Console.WriteLine($"объём данных{arr.Length}");
    foreach (var i in timeList)
    {
        Console.WriteLine(i);
    }
}
Helper.SaveResults(results);