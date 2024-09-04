using System.Xml.Serialization;

[XmlRoot(ElementName="sender", Namespace="")]
public class SenderXml { 

    [XmlElement(ElementName="company", Namespace="")] 
    public string Company { get; set; } = "firma nadawcy";

    [XmlElement(ElementName="name", Namespace="")] 
    public string Name { get; set; } = "imie i nazwisko nadawcy";

    [XmlElement(ElementName="address", Namespace="")] 
    public string Address { get; set; } = "adres nadawcy";

    [XmlElement(ElementName="city", Namespace="")] 
    public string City { get; set; } = "miasto nadawcy";

    [XmlElement(ElementName="countryCode", Namespace="")] 
    public string CountryCode { get; set; } = "PL"; 

    [XmlElement(ElementName="postalCode", Namespace="")] 
    public string PostalCode { get; set; } = "02274";

    [XmlElement(ElementName="phone", Namespace="")] 
    public string Phone { get; set; } = "123 123 123";

    [XmlElement(ElementName="email", Namespace="")] 
    public string Email { get; set; } = "nazwa@domena-nadawcy.pl";
}