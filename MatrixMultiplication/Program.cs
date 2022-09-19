using System.Diagnostics;
using HelperLibrary;

var data = File.ReadAllLines("BigMatrix.csv").Select(line => line.Split(';')).ToArray();
var matrix = ConvertMatrix(data);
Stopwatch stopwatch = new Stopwatch();
string results = "n;k;Time(milliseconds)\n";
for (int n = 1; n <= 20; n++)
{
    for (int k = 1; k <= 20; k++)
    {
        int[,] matrix1 = GetSmallMatrix(matrix, n, k);
        int[,] matrix2 = GetSmallMatrix(matrix, k, n);
        
        List<double> timeList = new List<double>();
        for (int m = 1; m <= 20; m++)
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
            timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
            stopwatch.Stop();
            File.AppendAllText("check.txt", stopwatch.Elapsed.TotalMilliseconds + "\n");
        }
        Helper.TimeListCleaning(timeList);
        var averageTime = timeList.ToArray().Sum() / Helper.FindCount(timeList);
        File.AppendAllText("check.txt", $"\n{n} попытка, матрица ранга {n}x{k}*{k}x{n}, среднее время {Math.Round(averageTime, 3)}\n" + "~~~~~~~~~~~~~~\n");
        results += $"{n};{k};{Math.Round(averageTime, 3)}\n";
    }
}

Helper.SaveResults(results);

static int[,] ConvertMatrix(string[][] badMatrix)
{
    var colCountHs = new HashSet<int>();

    for (int i = 0; i < badMatrix.Length; i++)
    {
        colCountHs.Add(badMatrix[i].Length);
    }

    int[,] matrix = new int[badMatrix.Length, colCountHs.Max()];

    for (int i = 0; i < badMatrix.Length; i++)
    {
        for (int j = 0; j < badMatrix[i].Length; j++)
        {
            matrix[i, j] = int.Parse(badMatrix[i][j]);
        }
    }
    return matrix;
}

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

static int[,] CreateMatrix(int k, int n)
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
