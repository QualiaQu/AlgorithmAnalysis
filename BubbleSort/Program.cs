﻿using System.Diagnostics;
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
    for (int k = 1; k <= 10; k++)
    {
        int[] copy = new int[arr.Length];
        arr.CopyTo(copy, 0);
        stopwatch.Restart();
        BubbleSort(copy);
        timeList.Add(stopwatch.Elapsed.TotalMilliseconds * 1000);
        stopwatch.Stop();
    }
    Array.Resize(ref arr, arr.Length - 20);
    
    Helper.TimeListCleaning(timeList);

    var averageTime = timeList.ToArray().Sum() / Helper.FindCount(timeList);
    timeList.Clear();
    
    results += $"{arr.Length};{Math.Round(averageTime, 3)}\n";
}
Helper.SaveResults(results);
static void BubbleSort(int[] anArray)
{
    for (int i = 0; i < anArray.Length; i++)
    {
        for (int j = 0; j < anArray.Length - 1 - i; j++)
        {
            if (anArray[j] > anArray[j + 1])
            {
                Swap(ref anArray[j], ref anArray[j + 1]);
            }
        }
    }
}

static void Swap(ref int aFirstArg, ref int aSecondArg)
{
    (aFirstArg, aSecondArg) = (aSecondArg, aFirstArg); 
}