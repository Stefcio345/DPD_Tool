using System.Data.SqlTypes;
using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="packages", Namespace="")]
public class PackagesObjXml { 
    
    [XmlElement(ElementName="Package")] 
    public PackageObjXml? Package { get; set; }
    
    [XmlElement(ElementName="packageId")] 
    public string? PackageId { get; set; }
    
    [XmlElement("parcels")]
    public List<ParcelsObjXml>? Parcels { get; set; }

    [XmlElement(ElementName = "payerType", Namespace = "")]
    public string? PayerType { get; set; }

    [XmlElement(ElementName = "thirdPartyFID", Namespace = "")]
    public string? ThirdPartyFID { get; set; }

    [XmlElement(ElementName = "receiver", Namespace = "")]
    public ReceiverObjXml? Receiver { get; set; }

    [XmlElement(ElementName = "sender", Namespace = "")]
    public SenderObjXml? Sender { get; set; }

    [XmlElement(ElementName = "ref1", Namespace = "")]
    public string? Ref1 { get; set; }

    [XmlElement(ElementName="ref2", Namespace="")] 
    public string? Ref2 { get; set; }

    [XmlElement(ElementName="ref3", Namespace="")] 
    public string? Ref3 { get; set; }

    [XmlElement(ElementName = "services", Namespace = "")]
    public ServicesObjXml? Services { get; set; }
    
    public PackagesObjXml()
    {
        Package = null;
        PayerType = "THIRD_PARTY";
        ThirdPartyFID = "1495";
        Ref1 = "ref1_abc";
        Ref2 = "ref2_def";
        Ref3 = "ref3_ghi";
        Sender = new SenderObjXml();
        Receiver = new ReceiverObjXml();
        Services = new ServicesObjXml();
        Parcels = [new ParcelsObjXml()];
    }

    public PackagesObjXml(CallTypes type)
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
                Parcels = [new ParcelsObjXml(CallTypes.LABEL, "XXXXXXXXXXXXXU")];
                break;
            default:
                break;
        }
        
    }
}

[XmlRoot(ElementName="Package")]
public class PackageObjXml { 

    [XmlElement(ElementName="Status")] 
    public string? Status { get; set; } 
    
    [XmlElement(ElementName="ValidationDetails", Namespace="")] 
    public ValidationDetails? ValidationDetails { get; set; } 

    [XmlElement(ElementName="PackageId")] 
    public string PackageId { get; set; } 

    [XmlElement(ElementName="Parcels")] 
    public ParcelsObjXml? Parcels { get; set; } 
}