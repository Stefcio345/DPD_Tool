﻿using System.Security.Cryptography;
using System.Xml.Serialization;

namespace DPD_App;

public class SoapError
{
    public string Title;
    public string Content;

    public SoapError(string title, string content)
    {
        Title = title;
        Content = content;
        LoggingService.Log(LoggingType.ERROR, title + "\nMessage: " + content);
    }
}

public class SoapException: Exception
{
    public string Title;
    public List<SoapError> Errors = new List<SoapError>();

    public SoapException(string title): base(title)
    {
        Title = title;
    }
    
    public SoapException(string title, SoapError error): base(title)
    {
        Title = title;
        Errors.Add(error);
    }
    
    public SoapException(string title, List<SoapError> errors): base(title)
    {
        Title = title;
        Errors.AddRange(errors);
    }
}

[XmlRoot(ElementName="exception", Namespace="http://jax-ws.dev.java.net/")]
public class XmlException { 

    [XmlElement(ElementName="message", Namespace="")] 
    public string Message { get; set; } 

    [XmlElement(ElementName="stackTrace", Namespace="http://www.w3.org/2003/05/soap-envelope")] 
    public string StackTrace { get; set; } 

    [XmlAttribute(AttributeName="ns2", Namespace="http://www.w3.org/2000/xmlns/")] 
    public string Ns2 { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}

[XmlRoot(ElementName="detail", Namespace="")]
public class Detail { 

    [XmlElement(ElementName="exception", Namespace="http://jax-ws.dev.java.net/")] 
    public XmlException Exception { get; set; } 
}

[XmlRoot(ElementName="Fault", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
public class Fault { 

    [XmlElement(ElementName="faultcode", Namespace="")] 
    public string Faultcode { get; set; } 

    [XmlElement(ElementName="faultstring", Namespace="")] 
    public string Faultstring { get; set; } 

    [XmlElement(ElementName="detail", Namespace="")] 
    public Detail Detail { get; set; } 
}