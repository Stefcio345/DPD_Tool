using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="generateReturnLabelV1", Namespace="http://dpdservices.dpd.com.pl/")]
public class GenerateReturnLabelV1: ISoapBody, IAuthData
{

    [XmlElement(ElementName = "returnedWaybillsV1", Namespace = "")]
    public ReturnedWaybillsV1 ReturnedWaybillsV1 { get; set; } = new ReturnedWaybillsV1();

    [XmlElement(ElementName = "receiver", Namespace = "")]
    public ReceiverXml Receiver { get; set; } = new ReceiverXml();

    [XmlElement(ElementName="outputDocFormatV1", Namespace="")] 
    public string OutputDocFormatV1 { get; set; } = "PDF";

    [XmlElement(ElementName="outputDocPageFormatV1", Namespace="")] 
    public string OutputDocPageFormatV1 { get; set; } = "A4";

    [XmlElement(ElementName="outputLabelType", Namespace="")] 
    public string OutputLabelType { get; set; } = "RETURN";

    [XmlElement(ElementName = "authDataV1", Namespace = "")]
    public AuthDataV1 AuthDataV1 { get; set; } = new AuthDataV1();
    
    public void UpdateAuthData(string login, string password, string masterFid)
    {
        this.AuthDataV1.Login = login;
        this.AuthDataV1.Password = password;
        this.AuthDataV1.MasterFid = masterFid;
    }
    public void UpdateAuthData(Profile profile)
    {
        this.AuthDataV1.Login = profile.Login;
        this.AuthDataV1.Password = profile.Password;
        this.AuthDataV1.MasterFid = profile.MasterFid;
    }

    public string CreateSoapEnvelope()
    {
        var SoapEnvelope = new Envelope();
        SoapEnvelope.Body.GenerateReturnLabelV1 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}