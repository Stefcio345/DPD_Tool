using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="parcels", Namespace="")]
public class Parcels { 
    
    [XmlElement(ElementName="Parcel")] 
    public Parcel? Parcel { get; set; } 
    
    [XmlElement(ElementName="statusInfo", Namespace="")] 
    public StatusInfo? StatusInfo { get; set; } 

    [XmlElement(ElementName="waybill")] 
    public string? Waybill { get; set; } 

    [XmlElement("weight", Namespace = "")]
    public string Weight {get;set;}
    
    [XmlElement(ElementName="adrWeight", Namespace = "")]
    public string AdrWeight {get;set;}

    [XmlElement(ElementName="sizeX", Namespace="")] 
    public string SizeX { get; set; }

    [XmlElement(ElementName="sizeY", Namespace="")] 
    public string SizeY { get; set; }

    [XmlElement(ElementName="sizeZ", Namespace="")] 
    public string SizeZ { get; set; }

    [XmlElement(ElementName="content", Namespace="")] 
    public string Content { get; set; }

    [XmlElement(ElementName="customerData1", Namespace="")] 
    public string CustomerData1 { get; set; }

    [XmlElement(ElementName="customerData2", Namespace="")] 
    public string CustomerData2 { get; set; }

    [XmlElement(ElementName="customerData3", Namespace="")] 
    public string CustomerData3 { get; set; }

    public Parcels()
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
    
    public Parcels(CallTypes type)
    {
        switch (type)
        {
            case CallTypes.LABEL:
                Waybill = "XXXXXXXXXXXXXU";
                break;
            default:
                break;
        }
        
    }
}

[XmlRoot(ElementName="Parcel")]
public class Parcel { 

    [XmlElement(ElementName="Status")] 
    public string Status { get; set; } 

    [XmlElement(ElementName="ParcelId")] 
    public int ParcelId { get; set; } 

    [XmlElement(ElementName="Waybill")] 
    public string Waybill { get; set; } 
}