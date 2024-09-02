using System.Text.RegularExpressions;

namespace DPD_App;

public class Logger
{
    public static AppSettings Settings { get; set; }
    public static void Log(LoggingType type, string content)
    {
        //TODO Add logging to a file
        //Dont log if settings turned off
        if (!Settings.LogRequests) return;
        
        var newstring = "";
        //Remove newlines
        if (type == LoggingType.REQUEST || type == LoggingType.RESPONSE)
            newstring = content.Replace(Environment.NewLine, "").Replace("\n", "");
        else newstring = content;
        //Remove multiple spaces
        newstring = Regex.Replace(newstring, "[ ]+", " ");
        Console.WriteLine($"[{DateTime.Now}] {type}: {newstring}");
    }
}