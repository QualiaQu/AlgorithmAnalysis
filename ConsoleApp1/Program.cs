using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[2000];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 100);
}
File.WriteAllText("results.txt", string.Empty);
for (int i = 5; i >= 1; i--)
{
    double averageTime = 0;
    for (int k = 1; k <= 5; k++)
    {
        ulong sum = 1;
        stopwatch.Restart();
        foreach (var t in arr)
        {
            sum *= (ulong)t;
        }
        
        stopwatch.Stop();
        File.AppendAllText("results.txt", stopwatch.Elapsed.TotalMilliseconds + "\n");
        averageTime += stopwatch.Elapsed.TotalMilliseconds;
    }
    averageTime /= 5;
    File.AppendAllText("results.txt",  $"\n{i} попытка, массив длинной {arr.Length}, среднее время {Math.Round(averageTime, 4)}\n" + "~~~~~~~~~~~~~~\n");
    Array.Resize(ref arr, arr.Length - 400);
}