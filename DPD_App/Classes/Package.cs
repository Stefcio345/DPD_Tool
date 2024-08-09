using System.Xml.Serialization;

[XmlRoot(ElementName="Package")]
public class Package { 

    [XmlElement(ElementName="Status")] 
    public string Status { get; set; } 

    [XmlElement(ElementName="PackageId")] 
    public int PackageId { get; set; } 

    [XmlElement(ElementName="Parcels")] 
    public Parcels Parcels { get; set; } 
}