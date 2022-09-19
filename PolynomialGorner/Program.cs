using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();

int[] arr = new int[10000];
for (int i = 0; i < arr.Length; i++)
{
    arr[i] = rand.Next(1, 50);
}

string results = "Объём данных;Время полинома (миллисекунды);Время Горнера (миллисекунды)\n";
string checkResultsDir = "Время полинома (миллисекунды);Время прямого (миллисекунды)\n";
string checkResultsGor = "Время полинома (миллисекунды);Время Горнера (миллисекунды)\n";

while (arr.Length != 0)
{
    List<double> timeListDirect = new List<double>();
    List<double> timeListGorn = new List<double>();
    for (int k = 1; k <= 100; k++) 
    {
        int[] copyDirect = new int[arr.Length];
        int[] copyGorn = new int[arr.Length];
        
        arr.CopyTo(copyDirect, 0);
        arr.CopyTo(copyGorn, 0);
        
        stopwatch.Restart();
        var direct = Direct(copyDirect);
        stopwatch.Stop();
        timeListDirect.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        checkResultsDir += $"{arr.Length};{Math.Round(stopwatch.Elapsed.TotalMilliseconds * 1000, 3)}\n";
        
        stopwatch.Restart();
        var gorner = Gorner(copyGorn);
        stopwatch.Stop();
        timeListGorn.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        checkResultsGor += $"{arr.Length};{Math.Round(stopwatch.Elapsed.TotalMilliseconds * 1000, 3)}\n";
    }

    Helper.TimeListCleaning(timeListDirect);
    var averageTimeDirect = timeListDirect.ToArray().Sum() / Helper.FindCount(timeListDirect);
    timeListDirect.Clear();
    
    Helper.TimeListCleaning(timeListGorn);
    var averageTimeGorn = timeListGorn.ToArray().Sum() / Helper.FindCount(timeListGorn);
    timeListGorn.Clear();
    
    results += $"{arr.Length};{Math.Round(averageTimeDirect, 3)};{Math.Round(averageTimeGorn, 3)}\n";
    Array.Resize(ref arr, arr.Length - 50);
}

File.WriteAllText(Path.GetFullPath("./checkDir.csv"), string.Empty);
File.AppendAllText(Path.GetFullPath("./checkDir.csv"), checkResultsDir);

File.WriteAllText(Path.GetFullPath("./checkGor.csv"), string.Empty);
File.AppendAllText(Path.GetFullPath("./checkGor.csv"), checkResultsGor);

Helper.SaveResults(results);

static double Direct(int[] array)
{
    double x = 1.5;
    double result = 0;

    for (int k = 1; k < array.Length + 1; k++)
    {
        result += array[k - 1] * Math.Pow(x, k - 1);
    }

    return result;
}

static double Gorner(int[] a, int i = 0)
{
    double x = 1.5;
    if (i >= a.Length)
        return 0;
    return a[i] + x * Gorner(a, i + 1);
}