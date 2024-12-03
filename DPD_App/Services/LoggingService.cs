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

    public static string RemoveNewLinesAndSpaces(string str)
    {
        //Remove newlines
        var newstring = "";
        newstring = str.Replace(Environment.NewLine, "").Replace("\n", "");
        //Remove multiple spaces
        return Regex.Replace(newstring, "\\s+", " ");
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
    
    public static string DecodeBase64InString(string str, string tagName)
    {
        var match = Regex.Match(str, @$"<\s*{tagName}\b[^>]*>(.*?)<\/{tagName}>");
        
        try
        {
            // Try decoding the string and check if it converts back successfully
            byte[] data = Convert.FromBase64String(match.Groups[1].Value);
            var DecodedData = System.Text.Encoding.UTF8.GetString(data);
        
            //Swap Base64 with decoded version
            return str.Remove(match.Groups[1].Index, match.Groups[1].Length)
                .Insert(match.Groups[1].Index, DecodedData);
        }
        catch (FormatException)
        {
            return str;
        }
    }
    
    public static string EncodeBase64InString(string str, string tagName)
    {
        var match = Regex.Match(str, @$"<\s*{tagName}\b[^>]*>(.*?)<\/{tagName}>");
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(match.Groups[1].Value);
        var EncodedData = System.Convert.ToBase64String(plainTextBytes);
        
        //Swap data with encoded version
        return str.Remove(match.Groups[1].Index, match.Groups[1].Length)
            .Insert(match.Groups[1].Index, EncodedData);
    }
}