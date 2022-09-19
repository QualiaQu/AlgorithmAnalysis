namespace HelperLibrary;

public static class Helper
{
    public static void SaveResults(string results)
    {
        File.WriteAllText(Path.GetFullPath("./results.csv"), string.Empty);
        File.AppendAllText(Path.GetFullPath("./results.csv"), results);
    }
    public static void TimeListCleaning(List<double> timeList)
    {
        var min = timeList.Min();
        for (var i = 0; i < timeList.Count; i++)
        {
            if (timeList[i] - min > 1.5)
            {
                timeList[i] = 0;
            }
        }
    }
    public static int FindCount(List<double> timeList)
    {
        int count = 0;
        foreach (var i in timeList)
        {
            if (i != 0)
            {
                count++;
            }
        }

        return count;
    }
    public static void PrintArray(int[] arr)
    {
        foreach (var i in arr)
        {
            Console.Write(i + " ");
        }

        Console.WriteLine();
    }
}