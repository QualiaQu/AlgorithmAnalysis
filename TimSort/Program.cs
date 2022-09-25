using System.Diagnostics;
using HelperLibrary;

const int run = 32;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[100000];
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
        int[] copy = new int[arr.Length];
        arr.CopyTo(copy, 0);
        stopwatch.Restart();
        TimSort(copy, copy.Length);
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }

    timeList.Remove(timeList.Max());
    
    var averageTime = timeList.ToArray().Sum() / 5;
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();
    
    Array.Resize(ref arr, arr.Length - 1000);
}

Helper.SaveResults(results);

static void InsertionSort(int[] arr, int left, int right)
{
    for (int i = left + 1; i <= right; i++)
    {
        int temp = arr[i];
        int j = i - 1;
        while (j >= left && arr[j] > temp)
        {
            arr[j+1] = arr[j];
            j--;
        }
        arr[j+1] = temp;
    }
}
    
static void Merge(int[] arr, int l, int m, int r)
{
        
    int len1 = m - l + 1, len2 = r - m;
    int[] left = new int[len1];
    int[] right = new int[len2];
    for (int x = 0; x < len1; x++)
        left[x] = arr[l + x];
    for (int x = 0; x < len2; x++)
        right[x] = arr[m + 1 + x];
       
    int i = 0;
    int j = 0;
    int k = l;
       
        
    while (i < len1 && j < len2)
    {
        if (left[i] <= right[j])
        {
            arr[k] = left[i];
            i++;
        }
        else
        {
            arr[k] = right[j];
            j++;
        }
        k++;
    }
       
    while (i < len1)
    {
        arr[k] = left[i];
        k++;
        i++;
    }
        
    while (j < len2)
    {
        arr[k] = right[j];
        k++;
        j++;
    }
}
static void TimSort(int[] arr, int n)
{
    for (int i = 0; i < n; i+=run)
        InsertionSort(arr, i,
            Math.Min((i+run-1), (n-1)));
        
    for (int size = run; size < n;
         size = 2*size)
    {
        for (int left = 0; left < n;
             left += 2*size)
        {
            int mid = left + size - 1;
            int right = Math.Min((left +
                2*size - 1), (n-1));
                
            if(mid < right)
                Merge(arr, left, mid, right);
        }
    }
}