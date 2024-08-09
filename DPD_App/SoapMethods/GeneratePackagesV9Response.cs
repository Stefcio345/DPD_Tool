using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="return")]
public class Return { 

    [XmlElement(ElementName="Status")] 
    public string Status { get; set; } 

    [XmlElement(ElementName="SessionId")] 
    public int SessionId { get; set; } 

    [XmlElement(ElementName="Packages")] 
    public Packages Packages { get; set; } 
}

[XmlRoot(ElementName="generatePackagesNumbersV9Response")]
public class GeneratePackagesNumbersV9Response { 

    [XmlElement(ElementName="return")] 
    public Return Return { get; set; } 

    [XmlAttribute(AttributeName="ns2")] 
    public string Ns2 { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}