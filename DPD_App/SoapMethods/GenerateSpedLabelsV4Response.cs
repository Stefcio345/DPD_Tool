using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="generateSpedLabelsV4Response", Namespace="http://dpdservices.dpd.com.pl/")]
public class GenerateSpedLabelsV4Response { 

    [XmlElement(ElementName="return", Namespace="")] 
    public Return Return { get; set; } 

    [XmlAttribute(AttributeName="ns2", Namespace="http://www.w3.org/2000/xmlns/")] 
    public string Ns2 { get; set; } 

    [XmlText] 
    public string Text { get; set; } 
}