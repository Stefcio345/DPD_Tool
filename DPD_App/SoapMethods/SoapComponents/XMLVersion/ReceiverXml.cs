using System.Xml.Serialization;
using DPD_App.Models;

[XmlRoot(ElementName="receiver", Namespace="")]
public class ReceiverXml{ 

    [XmlElement(ElementName="Company", Namespace="")] 
    public string Company { get; set; } = "firma odbiorcy";

    [XmlElement(ElementName="Name", Namespace="")] 
    public string Name { get; set; } = "imie i nazwisko odbiorcy";

    [XmlElement(ElementName = "Address", Namespace = "")]
    public string Address { get; set; } = "adres odbiorcy";

    [XmlElement(ElementName="City", Namespace="")] 
    public string City { get; set; } = "miasto odbiorcy";

    [XmlElement(ElementName="CountryCode", Namespace="")] 
    public string CountryCode { get; set; } = "PL"; 

    [XmlElement(ElementName="PostalCode", Namespace="")] 
    public string PostalCode { get; set; } = "02274";

    [XmlElement(ElementName="Phone", Namespace="")] 
    public string Phone { get; set; } = "123 123 123";

    [XmlElement(ElementName="Email", Namespace="")] 
    public string Email { get; set; } = "nazwa@domena-odbiorcy.pl";

    public ReceiverXml MapAddressData(AddressData addressData)
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