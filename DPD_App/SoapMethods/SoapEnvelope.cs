using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
public class Body
{

    [XmlElement(ElementName = "generatePackagesNumbersV9", Namespace = "http://dpdservices.dpd.com.pl/")]
    public GeneratePackagesNumbersV9? GeneratePackagesNumbersV9 { get; set; }
    
    [XmlElement(ElementName="generatePackagesNumbersV9Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GeneratePackagesNumbersV9Response? GeneratePackagesNumbersV9Response { get; set; } 
    
    [XmlElement(ElementName="generateSpedLabelsV4Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateSpedLabelsV4Response? GenerateSpedLabelsV4Response { get; set; } 
    
    [XmlElement(ElementName="generateSpedLabelsV4", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateSpedLabelsV4? GenerateSpedLabelsV4 { get; set; } 
    
    [XmlElement(ElementName="generateProtocolV2", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateProtocolV2? GenerateProtocolV2 { get; set; } 
    
    [XmlElement(ElementName="generateProtocolV2Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateProtocolV2Response? GenerateProtocolV2Response { get; set; } 
    
    [XmlElement(ElementName="generateInternationalPackageNumbersV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateInternationalPackageNumbersV1? GenerateInternationalPackageNumbersV1 { get; set; } 
    
    [XmlElement(ElementName="findPostalCodeV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public FindPostalCodeV1? FindPostalCodeV1 { get; set; } 
    
    [XmlElement(ElementName="getCourierOrderAvailabilityV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GetCourierOrderAvailabilityV1 GetCourierOrderAvailabilityV1 { get; set; } 
    
    [XmlElement(ElementName="Fault")] 
    public Fault? Fault { get; set; } 
}

[XmlRoot(ElementName="Envelope", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
public class Envelope { 

    [XmlElement(ElementName="Header", Namespace="http://schemas.xmlsoap.org/soap/envelope/")] 
    public object? Header { get; set; }

    [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public Body Body { get; set; } = new Body();

    [XmlAttribute(AttributeName="soapenv", Namespace="http://www.w3.org/2000/xmlns/")] 
    public string? Soapenv { get; set; } 

    [XmlAttribute(AttributeName="dpd", Namespace="http://www.w3.org/2000/xmlns/")] 
    public string? Dpd { get; set; } 

    [XmlText] 
    public string? Text { get; set; } 
}