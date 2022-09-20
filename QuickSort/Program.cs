using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[4000];
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
        int[] copy = new int[arr.Length];
        arr.CopyTo(copy, 0);
        stopwatch.Restart();
        QuickSort(copy, 0, copy.Length - 1);
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }
    Helper.TimeListCleaning(timeList);
    
    var averageTime = timeList.ToArray().Sum() / Helper.FindCount(timeList);
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();
    
    Array.Resize(ref arr, arr.Length - 20);
}

Helper.SaveResults(results);

int Partition (int[] array, int start, int end) 
{
    int temp;
    int marker = start;
    for ( int i = start; i < end; i++ ) 
    {
        if ( array[i] < array[end] ) 
        {
            temp = array[marker]; 
            array[marker] = array[i];
            array[i] = temp;
            marker += 1;
        }
    }
    temp = array[marker];
    array[marker] = array[end];
    array[end] = temp; 
    return marker;
}

void QuickSort (int[] array, int start, int end)
{
    if ( start >= end ) 
    {
        return;
    }
    int pivot = Partition (array, start, end);
    QuickSort (array, start, pivot-1);
    QuickSort (array, pivot+1, end);
}