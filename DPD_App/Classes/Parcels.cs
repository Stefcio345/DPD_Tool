using System.Xml.Serialization;

[XmlRoot(ElementName="parcels", Namespace="")]
public class Parcels { 
    
    [XmlElement(ElementName="Parcel")] 
    public Parcel Parcel { get; set; } 

    [XmlIgnore]
    public double Weight {get;set;} = 12.5;

    [XmlElement("weight", Namespace = "")]
    public string W {
        get { return Weight.ToString(); }
        set { Weight = double.Parse(value); } 
    }

    [XmlElement(ElementName="adrWeight", Namespace = "")]
    public double AdrWeight {get;set;}

    [XmlElement(ElementName="sizeX", Namespace="")] 
    public int SizeX { get; set; } = 10;

    [XmlElement(ElementName="sizeY", Namespace="")] 
    public int SizeY { get; set; } = 10;

    [XmlElement(ElementName="sizeZ", Namespace="")] 
    public int SizeZ { get; set; } = 10;

    [XmlElement(ElementName="content", Namespace="")] 
    public string Content { get; set; } = "Zawartość";

    [XmlElement(ElementName="customerData1", Namespace="")] 
    public string CustomerData1 { get; set; } = "Uwagi dla kuriera 1";

    [XmlElement(ElementName="customerData2", Namespace="")] 
    public string CustomerData2 { get; set; } = "Uwagi dla kuriera 2";

    [XmlElement(ElementName="customerData3", Namespace="")] 
    public string CustomerData3 { get; set; } = "Uwagi dla kuriera 3";
}