namespace DPD_App;

public class Logger
{
    public static void Log(string type, string content)
    {
        Console.WriteLine($"[{DateTime.Now}] {type}: {content.Replace(Environment.NewLine, "").Replace("\n", "")}");
    }
}