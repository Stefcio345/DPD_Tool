using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="findPostalCodeV1", Namespace="http://dpdservices.dpd.com.pl/")]
public class FindPostalCodeV1: ISoapBody, IAuthData 
{

    [XmlElement(ElementName = "postalCodeV1", Namespace = "")]
    public PostalCodeV1 PostalCodeV1 { get; set; } = new PostalCodeV1();

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
        SoapEnvelope.Body.FindPostalCodeV1 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}

[XmlRoot(ElementName="postalCodeV1", Namespace="")]
public class PostalCodeV1
{
    [XmlElement(ElementName = "countryCode", Namespace = "")]
    public string CountryCode { get; set; } = "PL";

    [XmlElement(ElementName = "zipCode", Namespace = "")]
    public string ZipCode { get; set; } = "02274";
}