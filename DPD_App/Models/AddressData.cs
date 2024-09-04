namespace DPD_App.Models;

public class AddressData
{
    public string Company { get; set; } = "firma odbiorcy";
    
    public string Name { get; set; } = "imie i nazwisko odbiorcy";
    
    public string Address { get; set; } = "adres odbiorcy";
    
    public string City { get; set; } = "miasto odbiorcy";
    
    public string CountryCode { get; set; } = "PL"; 
    
    public string PostalCode { get; set; } = "02274";
    
    public string Phone { get; set; } = "123 123 123";
    
    public string Email { get; set; } = "nazwa@domena-odbiorcy.pl";
}