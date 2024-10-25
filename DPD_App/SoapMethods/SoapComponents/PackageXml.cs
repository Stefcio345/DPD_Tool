using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="Package")]
public class PackageXml { 

    [XmlElement(ElementName="Status")] 
    public string? Status { get; set; } 
    
    [XmlElement(ElementName="ValidationDetails", Namespace="")] 
    public ValidationDetails? ValidationDetails { get; set; } 

    [XmlElement(ElementName="PackageId")] 
    public string PackageId { get; set; } 

    [XmlElement(ElementName="Parcels")] 
    public ParcelsXml? Parcels { get; set; } 
}