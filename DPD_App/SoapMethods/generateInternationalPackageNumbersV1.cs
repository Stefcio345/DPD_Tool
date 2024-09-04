using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="generateInternationalPackageNumbersV1", Namespace="http://dpdservices.dpd.com.pl/")]
public class GenerateInternationalPackageNumbersV1: ISoapBody, IAuthData { 

    [XmlElement(ElementName="internationalOpenUMLFeV1", Namespace="")] 
    public InternationalOpenUMLFeV1 InternationalOpenUMLFeV1 { get; set; } 

    [XmlElement(ElementName="authDataV1", Namespace="")] 
    public AuthDataV1 AuthDataV1 { get; set; } 
    
    
    public GenerateInternationalPackageNumbersV1()
    {
        AuthDataV1 = new AuthDataV1();
        InternationalOpenUMLFeV1 = new InternationalOpenUMLFeV1();
        InternationalOpenUMLFeV1.Packages.Services.pudoReturn = new object();
    }

    public override string ToString()
    {
        var serializer = new XmlSerializer(typeof(GenerateInternationalPackageNumbersV1));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, this);
            return textWriter.ToString();
        }
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
        SoapEnvelope.Body.GenerateInternationalPackageNumbersV1 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}

[XmlRoot(ElementName="internationalOpenUMLFeV1", Namespace="")]
public class InternationalOpenUMLFeV1 { 

    [XmlElement(ElementName="packages", Namespace="")] 
    public PackagesXml Packages { get; set; } = new PackagesXml();
}