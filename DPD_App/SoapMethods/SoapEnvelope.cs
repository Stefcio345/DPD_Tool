using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="Body", Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
public class Body
{
    //Generate Packages Numbers
    [XmlElement(ElementName = "generatePackagesNumbersV9", Namespace = "http://dpdservices.dpd.com.pl/")]
    public GeneratePackagesNumbersV9? GeneratePackagesNumbersV9 { get; set; }
    [XmlElement(ElementName="generatePackagesNumbersV9Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GeneratePackagesNumbersV9Response? GeneratePackagesNumbersV9Response { get; set; } 
    
    //Generate SpedLabels
    [XmlElement(ElementName="generateSpedLabelsV4Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateSpedLabelsV4Response? GenerateSpedLabelsV4Response { get; set; } 
    [XmlElement(ElementName="generateSpedLabelsV4", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateSpedLabelsV4? GenerateSpedLabelsV4 { get; set; } 
    
    //Generate Protocol
    [XmlElement(ElementName="generateProtocolV2", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateProtocolV2? GenerateProtocolV2 { get; set; } 
    [XmlElement(ElementName="generateProtocolV2Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateProtocolV2Response? GenerateProtocolV2Response { get; set; } 
    
    //Generate International Package Numbers
    [XmlElement(ElementName="generateInternationalPackageNumbersV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateInternationalPackageNumbersV1? GenerateInternationalPackageNumbersV1 { get; set; } 
    [XmlElement(ElementName="generateInternationalPackageNumbersV1Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateInternationalPackageNumbersV1Response? GenerateInternationalPackageNumbersV1Response { get; set; } 

    //Find Postal Code
    [XmlElement(ElementName="findPostalCodeV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public FindPostalCodeV1? FindPostalCodeV1 { get; set; } 
    
    //Get Courier Order Availability
    [XmlElement(ElementName="getCourierOrderAvailabilityV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GetCourierOrderAvailabilityV1? GetCourierOrderAvailabilityV1 { get; set; } 
    
    //Generate Domestic Return Label
    [XmlElement(ElementName="generateDomesticReturnLabelV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateDomesticReturnLabelV1? GenerateDomesticReturnLabelV1 { get; set; } 
    [XmlElement(ElementName="generateDomesticReturnLabelV1Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateDomesticReturnLabelV1Response? GenerateDomesticReturnLabelV1Response { get; set; }
    
    //Generate Return Label
    [XmlElement(ElementName="generateReturnLabelV1", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateReturnLabelV1? GenerateReturnLabelV1 { get; set; } 
    [XmlElement(ElementName="generateReturnLabelV1Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public GenerateReturnLabelV1Response? GenerateReturnLabelV1Response { get; set; }
    
    //Append Parcels To Packgage
    [XmlElement(ElementName="appendParcelsToPackageV2", Namespace="http://dpdservices.dpd.com.pl/")] 
    public AppendParcelsToPackageV2? AppendParcelsToPackageV2 { get; set; } 
    [XmlElement(ElementName="appendParcelsToPackageV2Response", Namespace="http://dpdservices.dpd.com.pl/")] 
    public AppendParcelsToPackageV2Response? AppendParcelsToPackageV2Response { get; set; } 
    
    //Packages Pickup Call
    [XmlElement(ElementName="packagesPickupCallV4", Namespace="http://dpdservices.dpd.com.pl/")] 
    public PackagesPickupCallV4? PackagesPickupCallV4 { get; set; } 
    
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