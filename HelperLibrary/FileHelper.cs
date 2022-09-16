namespace HelperLibrary;

public static class FileHelper
{
    public static void SaveResults(string results)
    {
        File.WriteAllText(Path.GetFullPath("./results.csv"), string.Empty);

        Console.WriteLine(new String('-', 50));
        File.AppendAllText(Path.GetFullPath("./results.csv"), results);
        
        Console.WriteLine("Результаты успешно сохранены!");
    }
}