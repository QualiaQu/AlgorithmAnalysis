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
    Array.Resize(ref arr, arr.Length - 100);
    
    Helper.TimeListCleaning(timeList);
    
    var averageTime = timeList.ToArray().Sum() / Helper.FindCount(timeList);
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();
}
Helper.SaveResults(results);