﻿using System.Xml;
using Microsoft.VisualBasic;

namespace Tests;

static class Program
{
    static void Main()
    {
        // var results = Pow(10, 10);
        // Console.WriteLine("Pow: " + results + "\n");
        //
        // results = RecPow(10, 10);
        // Console.WriteLine("RecPow: " + results + "\n");
        //
        // results = QuickPow(10, 10);
        // Console.WriteLine("QuickPow: " + results + "\n");
        //
        // results = ClassicQuickPow(10, 10);
        // Console.WriteLine("ClassicQuickPow: " + results + "\n");
        double[] arr = {1, 2, 3, 4, 5, 100};

        Console.WriteLine(Polynamial(arr));
        Console.WriteLine(Gorner(arr));
    }

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

    static double Polynamial (double[] array)
    {
        double x = 1.5;
        double result = 0;

        for (int k = 1; k < array.Length + 1; k++)
        {
            result += array[k - 1] * Math.Pow(x, k - 1);
        }

        return result;
    }

    static double Gorner(double[] a, int i = 0)
    {
        double x = 1.5;
        if (i >= a.Length)
            return 0;
        return a[i] + x * Gorner(a, i + 1);
    }
}