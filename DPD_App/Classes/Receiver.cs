namespace DPD_App;

public class Receiver
{
    //Semi-required Company OR Name
    public string company { get; set; } = "firma odbiorcy";
    public string name { get; set; } = "imie i nazwisko odbiorcy";
    
    public string address { get; set; } = "adres odbiorcy";
    public string city { get; set; } = "miasto odbiorcy";
    public string countryCode { get; set; } = "PL";
    public string postalCode { get; set; } = "02274";
    public string? phone { get; set; } = "123 123 123";
    public string? email { get; set; } = "nazwa@domena-odbiorcy.pl";
    public string fid { get; set; } = "0";

    public string generateXML()
    {
        return $"<receiver>" +
               $"<{nameof(company)}>{company}</{nameof(company)}>" +
               $"<{nameof(name)}>{name}</{nameof(name)}>" +
               $"<{nameof(address)}>{address}</{nameof(address)}>" +
               $"<{nameof(city)}>{city}</{nameof(city)}>" +
               $"<{nameof(countryCode)}>{countryCode}</{nameof(countryCode)}>" +
               $"<{nameof(postalCode)}>{postalCode}</{nameof(postalCode)}>" +
               $"<{nameof(phone)}>{phone}</{nameof(phone)}>" +
               $"<{nameof(email)}>{email}</{nameof(email)}>" +
               $"<{nameof(fid)}>{fid}</{nameof(fid)}>" +
               $"</receiver>";
    }
}