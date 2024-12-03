using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App;


[XmlRoot(ElementName="Parcel")]
public class ParcelXml { 

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
    
    
    [XmlElement("Weight", Namespace = "")]
    public string? Weight {get;set;}
    
    [XmlElement(ElementName="WeightAdr", Namespace = "")]
    public string? AdrWeight {get;set;}

    [XmlElement(ElementName="SizeX", Namespace="")] 
    public string? SizeX { get; set; }

    [XmlElement(ElementName="SizeY", Namespace="")] 
    public string? SizeY { get; set; }

    [XmlElement(ElementName="SizeZ", Namespace="")] 
    public string? SizeZ { get; set; }

    [XmlElement(ElementName="Content", Namespace="")] 
    public string? Content { get; set; }

    [XmlElement(ElementName="CustomerData1", Namespace="")] 
    public string? CustomerData1 { get; set; }

    [XmlElement(ElementName="CustomerData2", Namespace="")] 
    public string? CustomerData2 { get; set; }

    [XmlElement(ElementName="CustomerData3", Namespace="")] 
    public string? CustomerData3 { get; set; }

    public ParcelXml()
    {
        Weight = "12.5";
        AdrWeight = null;
        SizeX = "10";
        SizeY = "10";
        SizeZ = "10";
        Content = "Zawartość";
        CustomerData1 = "Uwagi dla kuriera 1";
        CustomerData2 = "Uwagi dla kuriera 2";
        CustomerData3 = "Uwagi dla kuriera 3";
    }
    
    public ParcelXml MapParcel(Parcel parcel)
    {
        Weight = parcel.Weight;
        AdrWeight = parcel.AdrWeight;
        SizeX = parcel.SizeX;
        SizeY = parcel.SizeY;
        SizeZ = parcel.SizeZ;
        Content = parcel.Content;
        CustomerData1 = parcel.CustomerData1;
        CustomerData2 = parcel.CustomerData2;
        CustomerData3 = parcel.CustomerData3;
        return this;
    }
    
    public ParcelXml(CallTypes type, string waybill)
    {
        switch (type)
        {
            case CallTypes.LABEL:
                Weight = null;
                AdrWeight = null;
                SizeX = null;
                SizeY = null;
                SizeZ = null;
                Content = null;
                CustomerData1 = null;
                CustomerData2 = null;
                CustomerData3 = null;
                break;
            default:
                break;
        }
        
    }
    
}