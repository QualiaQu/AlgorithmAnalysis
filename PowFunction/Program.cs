using System.Diagnostics;
using HelperLibrary;

Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
int[] arr = new int[2000];
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
        double mul = 1;
        stopwatch.Restart();
        
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }
    Array.Resize(ref arr, arr.Length - 100);
    
    Helper.TimeListCleaning(timeList);
    var averageTime = timeList.ToArray().Sum() / Helper.FindCount(timeList);
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
    timeList.Clear();
}
Helper.SaveResults(results);

static (int, int) Pow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);

        results.result = 1;
        results.countSteps++;
        
        int k = 0;
        results.countSteps++;
        
        while (k < n)
        {
            results.countSteps++;
            results.result *= x;
            
            k++;
            results.countSteps++;
        }
        
        return results;
    }

    static (int, int) RecPow(int x, int n)
    {
        (int result, int countSteps) result = (0,0);

        if (n == 0)
        {
            result.result = 1;
            result.countSteps++;
        }
        else
        {
            result.countSteps++;
            result = RecPow(x, n / 2);
            
            if (n % 2 == 1)
            {
                result.result = result.result * result.result * x;
                result.countSteps++;
            }
            else
            {
                result.result *= result.result;
                result.countSteps++;
            }
        }
        
        return result;
    }

    static (int, int) QuickPow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);

        int c = x;
        results.countSteps++;

        int k = n;
        results.countSteps++;
        
        if (k % 2 == 1)
        {
            results.result = c;
            results.countSteps++;
        }
        else
        {
            results.result = 1;
            results.countSteps++;
        }
        do
        {
            k /= 2;
            results.countSteps++;
            
            c *= c;
            results.countSteps++;
            
            if (k % 2 == 1)
            {
                results.result *= c;
                results.countSteps++;
            }
        } while (k != 0);
        
        return results;
    }

    static (int, int) ClassicQuickPow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);
        
        int c = x;
        results.countSteps++;
        
        results.result = 1;
        results.countSteps++;
        
        int k = n;
        results.countSteps++;
        
        while (k != 0)
        {
            if (k % 2 == 0)
            {
                c *= c;
                results.countSteps++;
                
                k /= 2;
                results.countSteps++;
            }
            else
            {
                results.result *= c;
                results.countSteps++;

                k -= 1;
                results.countSteps++;
            }
        }
        
        return results;
    }