namespace DPD_App;

public class LangCode: GenerateXML
{
    public string langCode { get; set; } = "PL";
    
    public string generateXML()
    {
        return $"<{nameof(langCode)}>{langCode}</{nameof(langCode)}>";
    }
}