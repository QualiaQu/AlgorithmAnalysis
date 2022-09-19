using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[10000];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 100);
}
string results = "Input data;Time (milliseconds)\n";
while (arr.Length != 0)
{
    List<double> timeList = new List<double>();
    for (int k = 1; k <= 10; k++)
    {
        double sum = 0;
        stopwatch.Restart();
        foreach (var t in arr)
        {
            sum += t;
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