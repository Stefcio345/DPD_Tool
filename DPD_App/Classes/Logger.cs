using System.Text.RegularExpressions;

namespace DPD_App;

public class Logger
{
    public static void Log(string type, string content)
    {
        //Remove newlines
        var newstring = content.Replace(Environment.NewLine, "").Replace("\n", "");
        //Remove multiple spaces
        newstring = Regex.Replace(newstring, "[ ]+", " ");
        Console.WriteLine($"[{DateTime.Now}] {type}: {newstring}");
    }
}