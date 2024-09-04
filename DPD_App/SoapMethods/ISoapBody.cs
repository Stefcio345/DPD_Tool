namespace DPD_App;

public interface ISoapBody
{
    public string CreateSoapEnvelope();
}

public interface IAuthData
{
    public void UpdateAuthData(Profile profile);
}