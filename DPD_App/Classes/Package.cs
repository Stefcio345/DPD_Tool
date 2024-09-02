using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="Package")]
public class Package { 

    [XmlElement(ElementName="Status")] 
    public string? Status { get; set; } 
    
    [XmlElement(ElementName="ValidationDetails", Namespace="")] 
    public ValidationDetails? ValidationDetails { get; set; } 

    [XmlElement(ElementName="PackageId")] 
    public int PackageId { get; set; } 

    [XmlElement(ElementName="Parcels")] 
    public Parcels? Parcels { get; set; } 
}