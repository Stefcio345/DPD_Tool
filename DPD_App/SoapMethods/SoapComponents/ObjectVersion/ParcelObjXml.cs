using System.Xml.Serialization;

namespace DPD_App;


[XmlRoot(ElementName="Parcel")]
public class ParcelObjXml { 

    [XmlElement(ElementName="Status")] 
    public string? Status { get; set; } 

    [XmlElement(ElementName="ParcelId")] 
    public string? ParcelId { get; set; } 

    [XmlElement(ElementName="Waybill")] 
    public string? Waybill { get; set; } 

    [XmlElement(ElementName="Reference", Namespace="")] 
    public object? Reference { get; set; } 
    
    [XmlElement(ElementName="ValidationDetails", Namespace="")] 
    public ValidationDetails? ValidationDetails { get; set; }
    
    //Needed for AppendParcelsToPackage, because they are returned with lower case letters, for some reason.
    [XmlElement(ElementName="parcelId", Namespace="")] 
    public string? parcelId { get { return ParcelId; } set { ParcelId = value; } }

    [XmlElement(ElementName="status", Namespace="")] 
    public string? status { get { return Status; } set { Status = value; } }

    [XmlElement(ElementName="waybill", Namespace="")] 
    public string? waybill { get { return Waybill; } set { Waybill = value; } }
}