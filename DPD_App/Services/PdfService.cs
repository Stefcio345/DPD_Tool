namespace DPD_App;

public class PdfService
{
    public static AppSettings Settings { get; set; }
    public static string SaveBase64ToPDF(string base64Label, PrintType type)
    {
        string docPath = "./";
        
        switch (type)
        {
            case PrintType.Label:
                docPath = Globals.SaveLocation + "/" + Settings.LabelSaveLocation;
                break;
            case PrintType.Protocol:
                docPath = Globals.SaveLocation + "/" + Settings.ProtocolSaveLocation;
                break;
        }
        
        Directory.CreateDirectory(docPath);
        
        var filename = $"{DateTime.Now:dd-MM-yyyy_HHmmss}_{type}.pdf";
        
        using (FileStream stream = File.Create(Path.Combine(docPath, filename)))
        {
            Byte[] byteArray = Convert.FromBase64String(base64Label);
            stream.Write(byteArray, 0, byteArray.Length);
        }
        
        return filename;
    }
}