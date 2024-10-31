using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="return", Namespace="")]
public class Return { 

    [XmlElement(ElementName="Status", Namespace="")] 
    public string? Status { get; set; } 

    [XmlElement(ElementName="SessionId", Namespace="")] 
    public string? SessionId { get; set; } 

    [XmlElement(ElementName="Packages", Namespace="")] 
    public PackagesXml? Packages { get; set; } 
    
    [XmlElement(ElementName="documentData", Namespace="")] 
    public string? DocumentData { get; set; } 
    
    //Needed for append parcels to package
    [XmlElement(ElementName="parcels", Namespace="")] 
    public List<ParcelXml>? Parcels { get; set; } 

    [XmlElement(ElementName="session", Namespace="")] 
    public Session? Session { get; set; } 
    
    //Needed for AppendParcelsToPackage
    [XmlElement(ElementName="status", Namespace="")] 
    public string? status { get { return Status; } set { Status = value; } }
}

[XmlRoot(ElementName="generatePackagesNumbersV9Response", Namespace="http://dpdservices.dpd.com.pl/")]
public class GeneratePackagesNumbersV9Response: IReturnable { 

    [XmlElement(ElementName="return", Namespace="")] 
    public Return Return { get; set; } 

    [XmlAttribute(AttributeName="ns2", Namespace="http://www.w3.org/2000/xmlns/")] 
    public string Ns2 { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}