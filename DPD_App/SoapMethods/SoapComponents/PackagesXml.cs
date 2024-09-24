using System.Data.SqlTypes;
using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="packages", Namespace="")]
public class PackagesXml { 
    
    [XmlElement(ElementName="Package")] 
    public PackageXml? Package { get; set; }
    
    [XmlElement("parcels")]
    public List<ParcelsXml>? Parcels { get; set; }

    [XmlElement(ElementName = "payerType", Namespace = "")]
    public string? PayerType { get; set; }

    [XmlElement(ElementName = "thirdPartyFID", Namespace = "")]
    public string? ThirdPartyFID { get; set; }

    [XmlElement(ElementName = "receiver", Namespace = "")]
    public ReceiverXml? Receiver { get; set; }

    [XmlElement(ElementName = "sender", Namespace = "")]
    public SenderXml? Sender { get; set; }

    [XmlElement(ElementName = "ref1", Namespace = "")]
    public string? Ref1 { get; set; }

    [XmlElement(ElementName="ref2", Namespace="")] 
    public string? Ref2 { get; set; }

    [XmlElement(ElementName="ref3", Namespace="")] 
    public string? Ref3 { get; set; }

    [XmlElement(ElementName = "services", Namespace = "")]
    public ServicesXml? Services { get; set; }
    
    public PackagesXml()
    {
        Package = null;
        PayerType = "THIRD_PARTY";
        ThirdPartyFID = "1495";
        Ref1 = "ref1_abc";
        Ref2 = "ref2_def";
        Ref3 = "ref3_ghi";
        Sender = new SenderXml();
        Receiver = new ReceiverXml();
        Services = new ServicesXml();
        Parcels = [new ParcelsXml()];
    }

    public PackagesXml(CallTypes type)
    {
        switch (type)
        {
            case CallTypes.LABEL:
                Package = null;
                PayerType = null;
                ThirdPartyFID = null;
                Ref1 = null;
                Ref2 = null;
                Ref3 = null;
                Sender = null;
                Receiver = null;
                Services = null;
                Parcels = [new ParcelsXml(CallTypes.LABEL, "XXXXXXXXXXXXXU")];
                break;
            default:
                break;
        }
        
    }
}