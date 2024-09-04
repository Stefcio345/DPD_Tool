namespace DPD_App.Models;

public class Parcel
{
    public string? Status { get; set; } 
    
    public int? ParcelId { get; set; } 
    
    public object? Reference { get; set; } 
    
    public string Waybill { get; set; } 
    
    public string Weight { get; set; }
    
    public string? AdrWeight { get; set; }
    
    public string? SizeX { get; set; }
    
    public string? SizeY { get; set; }
    
    public string? SizeZ { get; set; }
    
    public string? Content { get; set; }
    
    public string? CustomerData1 { get; set; }
    
    public string? CustomerData2 { get; set; }
    
    public string? CustomerData3 { get; set; }
}