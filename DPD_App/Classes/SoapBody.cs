namespace DPD_App;

public interface SoapBody
{
    public string CreateSoapEnvelope();
}

public interface IAuthData
{
    public void UpdateAuthData(Profile profile);
}