using System.Xml.Serialization;
using DPD_App;
using DPD_App.SoapMethods.SoapComponents;

[XmlRoot(ElementName="Package")]
public class PackageXml { 

    [XmlElement(ElementName="Status")] 
    public string? Status { get; set; } 
    
    [XmlElement(ElementName="ValidationDetails", Namespace="")] 
    public ValidationDetails? ValidationDetails { get; set; } 

    [XmlElement(ElementName = "Parcels")] 
    public ParcelsXml? Parcels { get; set; } = new ParcelsXml();
    
    [XmlElement(ElementName="PackageId")] 
    public string? PackageId { get; set; }

    [XmlElement(ElementName = "PayerType", Namespace = "")]
    public string? PayerType { get; set; }

    [XmlElement(ElementName = "ThirdPartyFID", Namespace = "")]
    public string? ThirdPartyFID { get; set; }

    [XmlElement(ElementName = "Receiver", Namespace = "")]
    public ReceiverXml? Receiver { get; set; }

    [XmlElement(ElementName = "Sender", Namespace = "")]
    public SenderXml? Sender { get; set; }

    [XmlElement(ElementName = "Ref1", Namespace = "")]
    public string? Ref1 { get; set; }

    [XmlElement(ElementName="Ref2", Namespace="")] 
    public string? Ref2 { get; set; }

    [XmlElement(ElementName="Ref3", Namespace="")] 
    public string? Ref3 { get; set; }

    [XmlElement(ElementName = "Services", Namespace = "")]
    public ServicesXml? Services { get; set; }
    
    [XmlElement(ElementName="Customer")] 
    public Customer Customer { get; set; } 
    
    public PackageXml()
    {
        PayerType = "THIRD_PARTY";
        ThirdPartyFID = "1495";
        Ref1 = "ref1_abc";
        Ref2 = "ref2_def";
        Ref3 = "ref3_ghi";
        Sender = new SenderXml();
        Receiver = new ReceiverXml();
        Services = new ServicesXml();
        Customer = new Customer();
    }

    public PackageXml(CallTypes type)
    {
        switch (type)
        {
            case CallTypes.LABEL:
                PayerType = null;
                ThirdPartyFID = null;
                Ref1 = null;
                Ref2 = null;
                Ref3 = null;
                Sender = null;
                Receiver = null;
                Services = null;
                //Parcels = [new ParcelsObjectXml(CallTypes.LABEL, "XXXXXXXXXXXXXU")];
                break;
            default:
                break;
        }
        
    }
}

[XmlRoot(ElementName="Customer")]
public class Customer
{
    [XmlElement(ElementName = "FID")] public string FID { get; set; } = "1495";
}
