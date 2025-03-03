namespace DPD_App.Models;

public class AddressData
{
    public string Company { get; set; }
    
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string City { get; set; }
    
    public string CountryCode { get; set; }
    
    public string PostalCode { get; set; }
    
    public string Phone { get; set; }
    
    public string Email { get; set; }

    public AddressData()
    {
        Company = "firma";
        Name = "imie i nazwisko";
        Address = "adres";
        City = "miasto";
        CountryCode = "PL"; 
        PostalCode = "02274";
        Phone = "123 123 123";
        Email = "nazwa@domena.pl";
    }
    
    public AddressData(AddressTemplate addressTemplate = AddressTemplate.STANDARD)
    {
        switch (addressTemplate)
        {
            case AddressTemplate.SENDER:
                Company = "firma nadawcy";
                Name = "imie i nazwisko nadawcy";
                Address = "adres nadawcy";
                City = "miasto nadawcy";
                CountryCode = "PL"; 
                PostalCode = "02274";
                Phone = "123 123 123";
                Email = "nazwa@domena-nadawcy.pl";
                break;
            case AddressTemplate.RECEIVER:
                Company = "firma odbiorcy";
                Name = "imie i nazwisko odbiorcy";
                Address = "adres odbiorcy";
                City = "miasto odbiorcy";
                CountryCode = "PL"; 
                PostalCode = "02274";
                Phone = "123 123 123";
                Email = "nazwa@domena-odbiorcy.pl";
                break;
            case AddressTemplate.STANDARD:
            default:
                Company = "firma";
                Name = "imie i nazwisko";
                Address = "adres";
                City = "miasto";
                CountryCode = "PL"; 
                PostalCode = "02274";
                Phone = "123 123 123";
                Email = "nazwa@domena.pl";
                break;
        }
        
    }
}

public enum AddressTemplate
{
    STANDARD,
    SENDER,
    RECEIVER
}