using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[100000];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 100);
}
string results = "Input data;Time (milliseconds)\n";

while (arr.Length != 0)
{
    double averageTime = 0;
    for (int k = 1; k <= 5; k++)
    {
        stopwatch.Restart();
        int element = arr[0];
        stopwatch.Stop();
        averageTime += stopwatch.Elapsed.TotalMilliseconds;
    }
    averageTime /= 5;
    results += $"{arr.Length};{(Math.Round(averageTime, 6)) * 1000}\n";
    Array.Resize(ref arr, arr.Length - 10);
}

FileHelper.SaveResults(results);