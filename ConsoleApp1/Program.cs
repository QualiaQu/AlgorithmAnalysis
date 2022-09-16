namespace ConsoleApp1;

static class Program
{
    static void Main(string[] args)
    {
        List<double> list = new List<double>()
        {
            16.5, 15.8, 16.5, 17.1, 16.7
        };
        

        TimeListSorting(list);
        foreach (var i in list)
        {
            Console.WriteLine(i);
        }
    }

    static void TimeListSorting(List<double> timeList)
    {
        var min = timeList.Min();
        for (var i = 0; i < timeList.Count; i++)
        {
            if (timeList[i] - min > 1.3)
            {
                timeList[i] = 0;
            }
        }
    }
    // static void TimeListSorting(List<double> timeList)
    // {
    //     for (int i = 0; i < timeList.Count; i++)
    //     {
    //         try
    //         {
    //             if ((timeList[i] - timeList[i + 1] > 1) | ((timeList[i] - timeList[i + 1] < -1) & timeList[i] != 0))
    //             {
    //                 if (timeList[i] > timeList[i + 1])
    //                 {
    //                     timeList[i] = 0;
    //                 }
    //                 else
    //                 {
    //                     timeList[i + 1] = 0;
    //                 }
    //
    //             }
    //             if ((timeList[i] - timeList[i + 1] < -1) & timeList[i] != 0)
    //             {
    //                 timeList[i + 1] = 0;
    //             }
    //         }
    //         catch (Exception)
    //         {
    //             if ((timeList[i] - timeList[0] > 1 | timeList[i] - timeList[0] < 1) & timeList[0] != 0)
    //             {
    //                 if (timeList[i] > timeList[0])
    //                 {
    //                     timeList[i] = 0;
    //                 }
    //                 else
    //                 {
    //                     timeList[0] = 0;
    //                 }
    //             }
    //             break;
    //         }
    //     }
    // }
}