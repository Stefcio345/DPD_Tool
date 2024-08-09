using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="packages", Namespace="")]
public class Packages { 
    
    [XmlElement(ElementName="Package")] 
    public Package Package { get; set; }

    [XmlElement(ElementName = "parcels", Namespace = "")]
    public List<Parcels> Parcels { get; set; } = [new Parcels()];

    [XmlElement(ElementName = "payerType", Namespace = "")]
    public string PayerType { get; set; } = "THIRD_PARTY";

    [XmlElement(ElementName = "thirdPartyFID", Namespace = "")]
    public string ThirdPartyFID { get; set; } = Globals.MASTER_FID;

    [XmlElement(ElementName = "receiver", Namespace = "")]
    public Receiver Receiver { get; set; } = new Receiver();

    [XmlElement(ElementName = "sender", Namespace = "")]
    public Sender Sender { get; set; } = new Sender();

    [XmlElement(ElementName = "ref1", Namespace = "")]
    public string Ref1 { get; set; } = "ref1_abc";

    [XmlElement(ElementName="ref2", Namespace="")] 
    public string Ref2 { get; set; } = "ref2_def";

    [XmlElement(ElementName="ref3", Namespace="")] 
    public string Ref3 { get; set; } = "ref3_ghi";

    [XmlElement(ElementName = "services", Namespace = "")]
    public Services Services { get; set; } = new Services();
}