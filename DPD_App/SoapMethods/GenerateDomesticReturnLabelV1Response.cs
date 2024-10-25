using System.Xml.Serialization;

namespace DPD_App;

public class GenerateDomesticReturnLabelV1Response
{
    [XmlElement(ElementName="return", Namespace="")] 
    public Return Return { get; set; } 

    [XmlAttribute(AttributeName="ns2", Namespace="http://www.w3.org/2000/xmlns/")] 
    public string Ns2 { get; set; } 
}