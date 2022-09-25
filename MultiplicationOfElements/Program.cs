using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[1000000];
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
        double mul = 1;
        stopwatch.Restart();
        foreach (var t in arr)
        {
            mul *= t;
        }
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }
    timeList.Remove(timeList.Max());
    
    var averageTime = timeList.ToArray().Sum() / 5;
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();
    
    Array.Resize(ref arr, arr.Length - 100);
}
Helper.SaveResults(results);