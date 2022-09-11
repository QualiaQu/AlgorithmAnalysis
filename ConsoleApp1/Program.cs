using System.Diagnostics;
Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[100];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 3);
}

while (arr.Length != 0)
{
    for (int k = 0; k < 5; k++)
    {
        ulong sum = 1;
        stopwatch.Restart();
        for (int j = 0; j < arr.Length; j++)
        {
            sum *= (ulong)arr[j];
        }
        
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine(sum);

    }
    Array.Resize(ref arr, arr.Length - 20);
    Console.WriteLine("~~~~~~~~~~~~~~");

}