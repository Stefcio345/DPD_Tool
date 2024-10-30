using DPD_App.Json;

namespace DPD_App.Models;

public class MyPudoApiState
{
    public List<PudoItem> PudoItems = new List<PudoItem>();
    public List<SoapError> Errors = new List<SoapError>();
    
    public string? PudoLink;
    public Country? SelectedCountry;
    public string? PointID;
    public string? response;
    public string? SelectedFiltering = "Country";

    public string? City = "Warszawa";
    public string? ZipCode = "02274";
    public int maxPudoNumberValue = 25;

    public string? Latitude = "52.17506";
    public string? Longitude = "20.93867";
    public decimal Distance = 100;
    
    //Filters
    public bool partner = false;
    public bool servicePudoDisplay = false;
    public bool holidayTolerant = false;
    public bool dateFrom = false;
    
    public string? partnerValue;
    public int holidayTolerantValue;
    public DateTime? dateFromValue;
}