using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App;

[XmlRoot(ElementName="importPackagesXV1", Namespace="http://cr.dpdappservices.dpd.com.pl/")]
public class ImportPackagesXV1: ISoapBody, IAuthData
{

    [XmlElement(ElementName = "openUMLFXV2", Namespace = "")]
    public OpenUMLFXV2 OpenUMLFXV2 { get; set; } = new OpenUMLFXV2();

    [XmlElement(ElementName = "pkgNumsGenerationPolicyV1", Namespace = "")]
    public string PkgNumsGenerationPolicyV1 { get; set; } = "ALL_OR_NOTHING";

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
        SoapEnvelope.Body.ImportPackagesXV1 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(var textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            var text = LoggingService.EncodeBase64InString(textWriter.ToString(), "openUMLFXV2");
            return text;
        }
    }
    
    public string CreateDecodedSoapEnvelope()
    {
        var SoapEnvelope = new Envelope();
        SoapEnvelope.Body.ImportPackagesXV1 = this;
        
        var serializer = new XmlSerializer(typeof(Envelope));
        using(var textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}

[XmlRoot(ElementName="openUMLFXV2")]
public class OpenUMLFXV2 { 

    [XmlElement(ElementName="Packages")] 
    public PackagesXml Packages { get; set; }

    public OpenUMLFXV2()
    {
        Packages = new PackagesXml();
    }
}