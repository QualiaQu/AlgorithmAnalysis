using System.Diagnostics;

namespace MatrixMultiplication
{
    static class Program
    {
        static void Main(string[] args)
        {
            //task2!
            int[,] newBigMatrixA = CreateMatrix(100, 100);
            int[,] newBigMatrixB = CreateMatrix(100, 100);
            Stopwatch stopwatch = new Stopwatch();
            string finishString = "n;k;Time(milliseconds)\n\n\n";
            for (int n = 1; n <= 100; n++)
            {
                finishString += ";";
                for (int k = 1; k <= 100; k++)
                {
                    int[,] matrix1 = GetSmallMatrix(newBigMatrixA, n, k);
                    int[,] matrix2 = GetSmallMatrix(newBigMatrixB, k, n);

                    double averageTime = 0;
                    for (int m = 1; m <= 5; m++)
                    {
                        if (matrix1.GetLength(1) != matrix2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
                        int[,] finishMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
                        stopwatch.Restart();
                        for (int i = 0; i < matrix1.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix2.GetLength(1); j++)
                            {
                                for (int z = 0; z < matrix2.GetLength(0); z++)
                                {
                                    finishMatrix[i, j] += matrix1[i, z] * matrix2[z, j];
                                }
                            }
                        }
                        stopwatch.Stop();
                        File.AppendAllText("results.txt", stopwatch.Elapsed.TotalMilliseconds * 1000 + "\n");
                        averageTime += stopwatch.Elapsed.TotalMilliseconds;

                    }
                    averageTime /= 5;
                    File.AppendAllText("results.txt", $"\n{n} попытка, матрица ранга {n}x{k}*{k}x{n}, среднее время {(Math.Round(averageTime, 4)) * 1000}\n" + "~~~~~~~~~~~~~~\n");
                    finishString += $"{(Math.Round(averageTime, 4)) * 1000};";
                }
                finishString += "\n";
            }
            HelperLibrary.Helper.SaveResults(finishString);
        }
        //метод получивший на вход большую матрицу, делает из нее матрицу заданного размера
        static int[,] GetSmallMatrix(int[,] bigMatrix, int n, int k)
        {
            int[,] smallmatrix = new int[n, k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    smallmatrix[i, j] = bigMatrix[i, j];
                }
            }
            return smallmatrix;
        }
        //вспомогательные методы
        public static int[,] CreateMatrix(int k, int n)
        {
            int[,] matrix1 = new int[k, n];
            Random rnd = new Random();
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix1[i, j] = rnd.Next(0, 100);
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
    }
}