using System.Xml.Serialization;

[XmlRoot(ElementName="Parcel")]
public class Parcel { 

    [XmlElement(ElementName="Status")] 
    public string Status { get; set; } 

    [XmlElement(ElementName="ParcelId")] 
    public int ParcelId { get; set; } 

    [XmlElement(ElementName="Waybill")] 
    public string Waybill { get; set; } 
}