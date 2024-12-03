using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="appendParcelsToPackageV2", Namespace="http://dpdservices.dpd.com.pl/")]
public class AppendParcelsToPackageV2: ISoapBody, IAuthData
{

    [XmlElement(ElementName = "parcelsAppend", Namespace = "")]
    public ParcelsAppend ParcelsAppend { get; set; } = new ParcelsAppend();

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
        SoapEnvelope.Body.AppendParcelsToPackageV2 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}

[XmlRoot(ElementName="parcelsAppend", Namespace="")]
public class ParcelsAppend
{

    [XmlElement(ElementName = "packagesearchCriteria", Namespace = "")]
    public PackagesearchCriteria PackagesearchCriteria { get; set; } = new PackagesearchCriteria();

    [XmlElement(ElementName = "parcels", Namespace = "")]
    public List<ParcelsObjXml> Parcels { get; set; } = [new ParcelsObjXml()];
}

[XmlRoot(ElementName="packagesearchCriteria", Namespace="")]
public class PackagesearchCriteria { 

    [XmlElement(ElementName="waybill", Namespace="")] 
    public string Waybill { get; set; } = "XXXXXXXXXXXXXU";
}