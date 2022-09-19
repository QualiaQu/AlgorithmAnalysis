using System.Xml;
using Microsoft.VisualBasic;

namespace Tests;

static class Program
{
    static void Main()
    {
        var results = Pow(1, 10);
        Console.WriteLine("Pow: " + results + "\n");
        
        results = RecPow(1, 10);
        Console.WriteLine("RecPow: " + results + "\n");
        
        results = QuickPow(1, 10);
        Console.WriteLine("QuickPow: " + results + "\n");
        
        results = ClassicQuickPow(1, 10);
        Console.WriteLine("ClassicQuickPow: " + results + "\n");
    }

    static (int, int) Pow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);
        
        results.result = 1;
        int k = 0;
        
        while (k < n)
        {
            results.countSteps++;
            results.result *= x;
            k++;
        }
        
        return results;
    }

    static (int, int) RecPow(int x, int n)
    {
        (int result, int countSteps) results = (0,0);

        if (n == 0)
        {
            results.result = 1;
            results.countSteps++;
        }
        else
        {
            results.countSteps++;
            results = RecPow(x, n / 2);
            
            if (n % 2 == 1)
            {
                results.countSteps++;
                results.result = results.result * results.result * x;
            }
            else
            {
                results.countSteps++;
                results.result *= results.result;
            }
        }
        
        return results;
    }

    static (int, int) QuickPow(int x, int n)
    {
        (int result, int countSteps) results = (0, 0);

        int c = x;
        
        int k = n;

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

        results.result = 1;

        int k = n;

        while (k != 0)
        {
            if (k % 2 == 0)
            {
                results.countSteps++;
                c *= c;
                
                k /= 2;
            }
            else
            {
                results.countSteps++;
                results.result *= c;
                k -= 1;
            }
        }
        
        return results;
    }
}