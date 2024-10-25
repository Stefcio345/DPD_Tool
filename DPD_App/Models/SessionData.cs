namespace DPD_App.Models;

public class SessionData
{
    public string SessionId { get; set; }
    public PackageData Packages { get; set; } = new PackageData();
}

public class PackageData
{
    public string PackageId { get; set; }
    public List<ParcelData> Parcels { get; set; } = new List<ParcelData>();
}

public class ParcelData
{
    public string ParcelId { get; set; }
    public string Waybill { get; set; }
}