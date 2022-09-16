namespace HelperLibrary;

public static class Helper
{
    public static void SaveResults(string results)
    {
        File.WriteAllText(Path.GetFullPath("./results.csv"), string.Empty);

        Console.WriteLine(new String('-', 50));
        File.AppendAllText(Path.GetFullPath("./results.csv"), results);
        
        Console.WriteLine("Результаты успешно сохранены!");
    }

    public static List<double> TimeListSorting(List<double> timeList)
    {
        var min = timeList.Min();
        for (var i = 0; i < timeList.Count; i++)
        {
            if (timeList[i] - min > 1)
            {
                timeList[i] = 0;
            }
        }
        return timeList;
    }
}