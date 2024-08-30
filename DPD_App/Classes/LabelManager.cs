namespace DPD_App;

public class LabelManager
{
    public static AppSettings Settings { get; set; }
    public static string SaveBase64ToPDF(string base64Label)
    {
        string docPath = Globals.SaveLocation + "/" + Settings.SaveLocation;
        Directory.CreateDirectory(docPath);
        
        var filename = $"{DateTime.Now:dd-MM-yyyy_HHmmss}_Label.pdf";
        
        using (FileStream stream = File.Create(Path.Combine(docPath, filename)))
        {
            Byte[] byteArray = Convert.FromBase64String(base64Label);
            stream.Write(byteArray, 0, byteArray.Length);
        }
        
        return filename;
    }
}