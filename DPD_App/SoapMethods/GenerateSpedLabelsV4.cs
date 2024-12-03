using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="dpdServicesParamsV1", Namespace="")]
public class DpdServicesParamsV1
{

    [XmlElement(ElementName = "policy", Namespace="")]
    public string Policy { get; set; } = "STOP_ON_FIRST_ERROR";

    [XmlElement(ElementName = "session", Namespace="")]
    public Session Session { get; set; } = new Session();
    
    [XmlElement(ElementName="pickupAddress", Namespace="")] 
    public PickupAddress? PickupAddress { get; set; } 
}

[XmlRoot(ElementName="generateSpedLabelsV4", Namespace="http://dpdservices.dpd.com.pl/")]
public class GenerateSpedLabelsV4: ISoapBody, IAuthData
{

    [XmlElement(ElementName = "dpdServicesParamsV1", Namespace="")]
    public DpdServicesParamsV1 DpdServicesParamsV1 { get; set; }

    [XmlElement(ElementName = "outputDocFormatV1", Namespace="")]
    public string OutputDocFormatV1 { get; set; }

    [XmlElement(ElementName = "outputDocPageFormatV1", Namespace="")]
    public string OutputDocPageFormatV1 { get; set; }

    [XmlElement(ElementName = "outputLabelType", Namespace="")]
    public string OutputLabelType { get; set; }

    [XmlElement(ElementName = "labelVariant", Namespace="")]
    public object? LabelVariant { get; set; }

    [XmlElement(ElementName = "authDataV1", Namespace="")]
    public AuthDataV1 AuthDataV1 { get; set; }

    public GenerateSpedLabelsV4()
    {
        DpdServicesParamsV1 = new DpdServicesParamsV1();
        OutputDocFormatV1 = "PDF";
        OutputDocPageFormatV1 = "LBL_PRINTER";
        OutputLabelType = "BIC3";
        LabelVariant = null;
        AuthDataV1 = new AuthDataV1();
    }
    
    public GenerateSpedLabelsV4(List<string> waybills)
    {
        DpdServicesParamsV1 = new DpdServicesParamsV1();
        if (DpdServicesParamsV1.Session.PackagesObj.Parcels != null)
        {
            DpdServicesParamsV1.Session.PackagesObj.Parcels = new List<ParcelsObjXml>();
            for (var i = 0; i < waybills.Count; i++)
            {
                DpdServicesParamsV1.Session.PackagesObj.Parcels.Add(new ParcelsObjXml(CallTypes.LABEL, waybills[i]));
            }
        }
        
        OutputDocFormatV1 = "PDF";
        OutputDocPageFormatV1 = "LBL_PRINTER";
        OutputLabelType = "BIC3";
        LabelVariant = null;
        AuthDataV1 = new AuthDataV1();
    }

    public override string ToString()
    {
        var serializer = new XmlSerializer(typeof(GenerateSpedLabelsV4));
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
        SoapEnvelope.Body.GenerateSpedLabelsV4 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}
