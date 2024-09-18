using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="generateProtocolV2", Namespace="http://dpdservices.dpd.com.pl/")]
public class GenerateProtocolV2: ISoapBody, IAuthData { 

    [XmlElement(ElementName="dpdServicesParamsV1", Namespace="")] 
    public DpdServicesParamsV1 DpdServicesParamsV1 { get; set; } 

    [XmlElement(ElementName="outputDocFormatV1", Namespace="")] 
    public string OutputDocFormatV1 { get; set; } 

    [XmlElement(ElementName="outputDocPageFormatV1", Namespace="")] 
    public string OutputDocPageFormatV1 { get; set; } 

    [XmlElement(ElementName="authDataV1", Namespace="")] 
    public AuthDataV1 AuthDataV1 { get; set; } 
    
    public GenerateProtocolV2()
    {
        DpdServicesParamsV1 = new DpdServicesParamsV1();
        OutputDocFormatV1 = "PDF";
        OutputDocPageFormatV1 = "LBL_PRINTER";
        AuthDataV1 = new AuthDataV1();
    }
    
    public GenerateProtocolV2(List<string> waybills)
    {
        DpdServicesParamsV1 = new DpdServicesParamsV1();
        if (DpdServicesParamsV1.Session.Packages.Parcels != null)
        {
            DpdServicesParamsV1.Session.Packages.Parcels = new List<ParcelsXml>();
            for (var i = 0; i < waybills.Count; i++)
            {
                DpdServicesParamsV1.Session.Packages.Parcels.Add(new ParcelsXml()
                {
                    Waybill = waybills[i]
                });
            }
        }
        
        OutputDocFormatV1 = "PDF";
        OutputDocPageFormatV1 = "LBL_PRINTER";
        AuthDataV1 = new AuthDataV1();
    }

    public override string ToString()
    {
        var serializer = new XmlSerializer(typeof(GenerateProtocolV2));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, this);
            return textWriter.ToString();
        }
    }

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
        SoapEnvelope.Body.GenerateProtocolV2 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}