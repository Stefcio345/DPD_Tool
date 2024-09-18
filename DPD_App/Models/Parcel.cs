namespace DPD_App.Models;

public class Parcel
{
    public string? Status { get; set; } 
    
    public int? ParcelId { get; set; } 
    
    public string? Waybill { get; set; } 
    
    public object? Reference { get; set; } 
    
    public string Weight { get; set; }
    
    public string? AdrWeight { get; set; }
    
    public string? SizeX { get; set; }
    
    public string? SizeY { get; set; }
    
    public string? SizeZ { get; set; }
    
    public string? Content { get; set; }
    
    public string? CustomerData1 { get; set; }
    
    public string? CustomerData2 { get; set; }
    
    public string? CustomerData3 { get; set; }

    public Parcel()
    {
        Weight = "12.5";
        SizeX = "10";
        SizeY = "10";
        SizeZ = "10";
        Content = "Zawartość";
        CustomerData1 = "Uwagi dla kuriera 1";
        CustomerData2 = "Uwagi dla kuriera 2";
        CustomerData3 = "Uwagi dla kuriera 3";
    }
    
    public Parcel(string weight, string? adrWeight, string? sizeX, string? sizeY, string? sizeZ, string? content, string? customerData1, string? customerData2, string? customerData3)
    {
        Weight = weight;
        AdrWeight = adrWeight;
        SizeX = sizeX;
        SizeY = sizeY;
        SizeZ = sizeZ;
        Content = content;
        CustomerData1 = customerData1;
        CustomerData2 = customerData2;
        CustomerData3 = customerData3;
    }
}