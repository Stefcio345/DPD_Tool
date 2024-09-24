using System.Xml.Serialization;
using DPD_App;
using DPD_App.Models;

[XmlRoot(ElementName="parcels", Namespace="")]
public class ParcelsXml{ 
    
    [XmlElement(ElementName="Parcel")] 
    public List<ParcelXml>? Parcel { get; set; } 
    
    [XmlElement(ElementName="statusInfo", Namespace="")] 
    public StatusInfo? StatusInfo { get; set; } 

    [XmlElement(ElementName="waybill")] 
    public string? Waybill { get; set; } 

    [XmlElement("weight", Namespace = "")]
    public string? Weight {get;set;}
    
    [XmlElement(ElementName="weightAdr", Namespace = "")]
    public string? AdrWeight {get;set;}

    [XmlElement(ElementName="sizeX", Namespace="")] 
    public string? SizeX { get; set; }

    [XmlElement(ElementName="sizeY", Namespace="")] 
    public string? SizeY { get; set; }

    [XmlElement(ElementName="sizeZ", Namespace="")] 
    public string? SizeZ { get; set; }

    [XmlElement(ElementName="content", Namespace="")] 
    public string? Content { get; set; }

    [XmlElement(ElementName="customerData1", Namespace="")] 
    public string? CustomerData1 { get; set; }

    [XmlElement(ElementName="customerData2", Namespace="")] 
    public string? CustomerData2 { get; set; }

    [XmlElement(ElementName="customerData3", Namespace="")] 
    public string? CustomerData3 { get; set; }

    public ParcelsXml()
    {
        Weight = "12.5";
        AdrWeight = null;
        Waybill = null;
        SizeX = "10";
        SizeY = "10";
        SizeZ = "10";
        Content = "Zawartość";
        CustomerData1 = "Uwagi dla kuriera 1";
        CustomerData2 = "Uwagi dla kuriera 2";
        CustomerData3 = "Uwagi dla kuriera 3";
    }
    
    public ParcelsXml MapParcel(Parcel parcel)
    {
        Weight = parcel.Weight;
        AdrWeight = parcel.AdrWeight;
        Waybill = parcel.Waybill;
        SizeX = parcel.SizeX;
        SizeY = parcel.SizeY;
        SizeZ = parcel.SizeZ;
        Content = parcel.Content;
        CustomerData1 = parcel.CustomerData1;
        CustomerData2 = parcel.CustomerData2;
        CustomerData3 = parcel.CustomerData3;
        return this;
    }
    
    public ParcelsXml(CallTypes type, string waybill)
    {
        switch (type)
        {
            case CallTypes.LABEL:
                Weight = null;
                AdrWeight = null;
                Waybill = null;
                SizeX = null;
                SizeY = null;
                SizeZ = null;
                Content = null;
                CustomerData1 = null;
                CustomerData2 = null;
                CustomerData3 = null;
                Waybill = waybill;
                break;
            default:
                break;
        }
        
    }
}

[XmlRoot(ElementName="Parcel")]
public class ParcelXml { 

    [XmlElement(ElementName="Status")] 
    public string? Status { get; set; } 

    [XmlElement(ElementName="ParcelId")] 
    public int? ParcelId { get; set; } 

    [XmlElement(ElementName="Waybill")] 
    public string? Waybill { get; set; } 

    [XmlElement(ElementName="Reference", Namespace="")] 
    public object? Reference { get; set; } 
    
    [XmlElement(ElementName="ValidationDetails", Namespace="")] 
    public ValidationDetails? ValidationDetails { get; set; }
}