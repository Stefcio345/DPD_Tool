﻿using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="session", Namespace="")]
public class Session
{

    [XmlElement(ElementName = "packages", Namespace="")]
    public PackagesObjXml PackagesObj { get; set; } = new PackagesObjXml(CallTypes.LABEL);
    
    [XmlElement(ElementName = "sessionId", Namespace="")]
    public string? SessionId { get; set; }

    [XmlElement(ElementName = "sessionType", Namespace="")]
    public string SessionType { get; set; } = "DOMESTIC";
    
    [XmlElement(ElementName="statusInfo", Namespace="")] 
    public StatusInfo? StatusInfo { get; set; } 
}

[XmlRoot(ElementName="statusInfo", Namespace="")]
public class StatusInfo { 

    [XmlElement(ElementName="status", Namespace="")] 
    public string Status { get; set; } 
    
    [XmlElement(ElementName="description", Namespace="")] 
    public string? Description { get; set; } 
    
}