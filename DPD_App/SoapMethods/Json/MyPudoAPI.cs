namespace DPD_App.Json;
public class OpeningHoursItem
{
    public int dayId { get; set; }
    public string startTm { get; set; }
    public string endTm { get; set; }
}

public class HolidayItem
{
    public string startTm { get; set; }
    public string endTm { get; set; }
}

public class PudoItem
{
    public bool ShowDetails { get; set; }
    public bool active { get; set; }
    public bool overloaded { get; set; }
    public string pudoId { get; set; }
    public int order { get; set; }
    public string pudoType { get; set; }
    public string pudoTypeInfo { get; set; }
    public string name { get; set; }
    public string language { get; set; }
    public string address1 { get; set; }
    public string locationHint { get; set; }
    public string zipCode { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string longitude { get; set; }
    public string latitude { get; set; }
    public bool parking { get; set; }
    public List<OpeningHoursItem> openingHoursItems { get; set; }
    public List<HolidayItem> holidayItems { get; set; }
    public bool? handicape { get; set; }
}

public class Error
{
    public string code { get; set; }
    public string subcode { get; set; }
    public string userMessage { get; set; }
}

public class Root
{
    public int quality { get; set; }
    public string requestID { get; set; }
    public List<PudoItem> pudoItems { get; set; }
    public string? code { get; set; }
    public string? message { get; set; }
    public List<Error> errors { get; set; } = new List<Error>();
}