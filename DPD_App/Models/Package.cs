namespace DPD_App.Models;

public class Package
{
    public List<Parcel> Parcels { get; set; }
    
    public string PayerType { get; set; }
    
    public string? ThirdPartyFID { get; set; }
    
    public AddressData Receiver { get; set; }
    
    public AddressData Sender { get; set; }
    
    public string? Ref1 { get; set; }
    
    public string? Ref2 { get; set; }
    
    public string? Ref3 { get; set; }
    
    public Services Services { get; set; }
}