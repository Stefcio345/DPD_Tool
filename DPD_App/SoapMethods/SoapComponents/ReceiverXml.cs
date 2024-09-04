using System.Xml.Serialization;

[XmlRoot(ElementName="receiver", Namespace="")]
public class ReceiverXml { 

    [XmlElement(ElementName="company", Namespace="")] 
    public string Company { get; set; } = "firma odbiorcy";

    [XmlElement(ElementName="name", Namespace="")] 
    public string Name { get; set; } = "imie i nazwisko odbiorcy";

    [XmlElement(ElementName = "address", Namespace = "")]
    public string Address { get; set; } = "adres odbiorcy";

    [XmlElement(ElementName="city", Namespace="")] 
    public string City { get; set; } = "miasto odbiorcy";

    [XmlElement(ElementName="countryCode", Namespace="")] 
    public string CountryCode { get; set; } = "PL"; 

    [XmlElement(ElementName="postalCode", Namespace="")] 
    public string PostalCode { get; set; } = "02274";

    [XmlElement(ElementName="phone", Namespace="")] 
    public string Phone { get; set; } = "123 123 123";

    [XmlElement(ElementName="email", Namespace="")] 
    public string Email { get; set; } = "nazwa@domena-odbiorcy.pl";
}