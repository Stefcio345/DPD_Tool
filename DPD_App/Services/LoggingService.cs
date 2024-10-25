using System.Text.RegularExpressions;

namespace DPD_App;

public class LoggingService
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
        newstring = Regex.Replace(newstring, "\\s+", " ");
        
        if(Settings.ShortenLogs)
            newstring = ShortenString(newstring);

        var logMessage = $"[{DateTime.Now}] {type}: {newstring}";
        if (Settings.LogToFile) FileService.SaveTextToFile(logMessage, Settings.LogSaveLocation); 
        if (Settings.LogToConsole) Console.WriteLine(logMessage);
    }

    private static string ShortenString(string str)
    {
        var maxLogLength = Settings.MaxLogSize;
        if (str.Length > maxLogLength) return str[..((maxLogLength/2)-3)] + "[***]" + str[^((maxLogLength/2)-2)..str.Length];
        return str;
    }
    
    public static string ShortenString(string str, int maxLength)
    {
        if (str.Length > maxLength) return str[..((maxLength/2)-3)] + "[***]" + str[^((maxLength/2)-2)..str.Length];
        return str;
    }
    
    public static string ShortenDocumentData(string str)
    {
        var match = Regex.Match(str, @"<documentData>(.*?)<\/documentData>");
        var shortenedDocumentData = ShortenString(match.Groups[1].Value, 200);
        
        //Swap dodcumentData with shortened version
        return str.Remove(match.Groups[1].Index, match.Groups[1].Length)
            .Insert(match.Groups[1].Index, shortenedDocumentData);
    }
}