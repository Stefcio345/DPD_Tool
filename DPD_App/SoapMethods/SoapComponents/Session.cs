using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="session", Namespace="")]
public class Session
{

    [XmlElement(ElementName = "packages", Namespace="")]
    public PackagesXml Packages { get; set; } = new PackagesXml(CallTypes.LABEL);

    [XmlElement(ElementName = "sessionType", Namespace="")]
    public string SessionType { get; set; } = "DOMESTIC";
    
    [XmlElement(ElementName="statusInfo", Namespace="")] 
    public StatusInfo? StatusInfo { get; set; } 
}

[XmlRoot(ElementName="statusInfo", Namespace="")]
public class StatusInfo { 

    [XmlElement(ElementName="status", Namespace="")] 
    public string? Status { get; set; } 
}