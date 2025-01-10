using DPD_App.Models;

namespace DPD_App;

public interface ISoapBody
{
    public string CreateSoapEnvelope();
}

public interface IAuthData
{
    public void UpdateAuthData(string login, string password, string masterFid);
    public void UpdateAuthData(Profile profile);
}