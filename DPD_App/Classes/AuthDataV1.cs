namespace DPD_App;

public class AuthDataV1: GenerateXML
{
    public string login { get; set; } = Globals.LOGIN;
    public string? masterFid { get; set; } = Globals.MASTER_FID;
    public string password { get; set; } = Globals.PASSWORD;

    public AuthDataV1()
    {
        
    }

    public string generateXML()
    {
        return "<authDataV1>" +
               $"<{nameof(login)}>{login}</{nameof(login)}>" +
               $"<{nameof(masterFid)}>{masterFid}</{nameof(masterFid)}>" +
               $"<{nameof(password)}>{password}</{nameof(password)}>" +
               "</authDataV1>";
    }
}