using System.Diagnostics;

// Stopwatch stopwatch = new Stopwatch();
// Random rand = new Random();
// int[] arr = new int[10000];
// for (int i = 0; i < arr.Length; i++)
// {
//     arr[i] = rand.Next(1, 100);
// }
// File.WriteAllText("results.txt", string.Empty);
// for (int i = 20; i >= 1; i--)
// {
//     double averageTime = 0;
//     for (int k = 1; k <= 20; k++)
//     {
//         ulong sum = 1;
//         stopwatch.Restart();
//         foreach (var t in arr)
//         {
//             sum += (ulong)t;
//         }
//         
//         stopwatch.Stop();
//         File.AppendAllText("results.txt", stopwatch.Elapsed.TotalMilliseconds * 1000 + "\n");
//         averageTime += stopwatch.Elapsed.TotalMilliseconds * 1000;
//     }
//     averageTime /= 5;
//     File.AppendAllText("results.txt",  $"\n{i} попытка, массив длинной {arr.Length}, среднее время {Math.Round(averageTime, 4)}\n" + "~~~~~~~~~~~~~~\n");
//     Array.Resize(ref arr, arr.Length - 500);
// }
//2 task
Stopwatch stopwatch = new Stopwatch();
File.WriteAllText("results2.txt", string.Empty);
for (int n = 1; n < 100; n++)
{
    int[,] matrix1 = CreateMatrix(n);
    int[,] matrix2 = CreateMatrix(n);
                
    double averageTime = 0;
    for (int k = 1; k <= 5; k++)
    {
        var matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
        stopwatch.Restart();
        if (matrix1.GetLength(1) == matrix2.GetLength(0))
        {
            for (int i = 0; i < matrix3.GetLength(0); i++)
            {
                for (int j = 0; j < matrix3.GetLength(1); j++)
                {
                    matrix3[i, j] = 0;
                    for (int m = 0; m < matrix1.GetLength(1); m++)
                    {
                        matrix3[i, j] += matrix1[i, m] * matrix2[m, j];
                    }
                }
            }
        }
        stopwatch.Stop();
        File.AppendAllText("results2.txt", stopwatch.Elapsed.TotalMilliseconds * 1000 + "\n");
        averageTime += stopwatch.Elapsed.TotalMilliseconds;
        PrintMatrix(matrix3);
    }
    averageTime /= 5;
    File.AppendAllText("results2.txt", $"\n{n} попытка, матрица ранга {n}, среднее время {(Math.Round(averageTime, 4)) * 1000}\n" + "~~~~~~~~~~~~~~\n");
    
}
int[,] CreateMatrix(int k)
{
    int[,] matrix1 = new int[k, k];
    Random rnd = new Random();
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            matrix1[i, j] = rnd.Next(0,100);
        }
    }
    return matrix1;
}
static void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],1}|");
            else Console.Write($"{matrix[i, j],1}");
        }
        Console.WriteLine("|");
    }
}