using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App;

[XmlRoot(ElementName="getEventsForWaybillV1")]
public class GetEventsForWaybillV1: ISoapBody, IAuthData
{

    [XmlElement(ElementName = "waybill")] public string Waybill { get; set; } = "XXXXXXXXXXXXXU";

    [XmlElement(ElementName = "eventsSelectType")]
    public string EventsSelectType { get; set; } = "ALL";

    [XmlElement(ElementName = "language")] public string Language { get; set; } = "PL";

    [XmlElement(ElementName = "authDataV1")]
    public AuthDataV1 AuthDataV1 { get; set; } = new AuthDataV1();
    
    public void UpdateAuthData(string login, string password, string masterFid)
    {
        this.AuthDataV1.Login = login;
        this.AuthDataV1.Password = password;
        this.AuthDataV1.Channel = masterFid;
        this.AuthDataV1.MasterFid = null;
    }
    
    public void UpdateAuthData(Profile profile)
    {
        this.AuthDataV1.Login = profile.Login;
        this.AuthDataV1.Password = profile.Password;
        this.AuthDataV1.Channel = profile.Channel;
        this.AuthDataV1.MasterFid = null;
    }
    
    public string CreateSoapEnvelope()
    {
        var SoapEnvelope = new Envelope();
        SoapEnvelope.Body.GetEventsForWaybillV1 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
        ns.Add("", "");
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope, ns);
            return textWriter.ToString();
        }
    }
}