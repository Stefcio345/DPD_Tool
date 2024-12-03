using System.Xml.Serialization;
using DPD_App.Models;

[XmlRoot(ElementName="sender", Namespace="")]
public class SenderXml{ 

    [XmlElement(ElementName="Company", Namespace="")] 
    public string Company { get; set; } = "firma nadawcy";

    [XmlElement(ElementName="Name", Namespace="")] 
    public string Name { get; set; } = "imie i nazwisko nadawcy";

    [XmlElement(ElementName="Address", Namespace="")] 
    public string Address { get; set; } = "adres nadawcy";

    [XmlElement(ElementName="City", Namespace="")] 
    public string City { get; set; } = "miasto nadawcy";

    [XmlElement(ElementName="CountryCode", Namespace="")] 
    public string CountryCode { get; set; } = "PL"; 

    [XmlElement(ElementName="PostalCode", Namespace="")] 
    public string PostalCode { get; set; } = "02274";

    [XmlElement(ElementName="Phone", Namespace="")] 
    public string Phone { get; set; } = "123 123 123";

    [XmlElement(ElementName="Email", Namespace="")] 
    public string Email { get; set; } = "nazwa@domena-nadawcy.pl";
    
    public SenderXml MapAddressData(AddressData addressData)
    {
        Company = addressData.Company;
        Name = addressData.Name;
        Address = addressData.Address;
        City = addressData.City;
        CountryCode = addressData.CountryCode;
        PostalCode = addressData.PostalCode;
        Phone = addressData.Phone;
        Email = addressData.Email;
        return this;
    }
}