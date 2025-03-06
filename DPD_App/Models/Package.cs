using System.Text.Json.Serialization;

namespace DPD_App.Models;

[JsonSerializable(typeof(Packages))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public class Package
{
    public List<Parcel> Parcels { get; set; }
    
    public string? PackageId { get; set; }
    
    public string? Base64Label { get; set; }
    public string? Base64Protocol { get; set; }
    public string PayerType { get; set; }
    
    public string? ThirdPartyFID { get; set; }
    
    public AddressData Receiver { get; set; }
    
    public AddressData Sender { get; set; }
    
    public string? Ref1 { get; set; }
    
    public string? Ref2 { get; set; }
    
    public string? Ref3 { get; set; }
    
    public Services Services { get; set; }
    
    public DateTime Created { get; set; }

    public bool International => Sender.CountryCode != Receiver.CountryCode;

    public Package()
    {
        Parcels = [new Parcel()];
        PayerType = "THIRD_PARTY";
        ThirdPartyFID = "1495";
        Receiver = new AddressData(AddressTemplate.RECEIVER);
        Sender = new AddressData(AddressTemplate.SENDER);
        Ref1 = "REF1_ABC";
        Ref2 = "REF2_DEF";
        Ref3 = "REF3_GHI";
        Services = new Services();
    }

    public Package(List<Parcel> parcels, string payerType, string? thirdPartyFid, AddressData receiver, AddressData sender, string? ref1, string? ref2, string? ref3, Services services)
    {
        Parcels = parcels;
        PayerType = payerType;
        ThirdPartyFID = thirdPartyFid;
        Receiver = receiver;
        Sender = sender;
        Ref1 = ref1;
        Ref2 = ref2;
        Ref3 = ref3;
        Services = services;
    }

    public async Task GenerateWaybills(Profile profile)
    {
       await PackageService.GenerateWaybills(this, profile);
    }
    
    public async Task GenerateProtocol(Profile profile)
    {
        await PackageService.GenerateProtocol(this, profile);
    }
    
}

public class Packages
{
    private static List<Package> List = new List<Package>();
    
    public static void RemovePackage(Package package)
    {
        List.Remove(package);
        SaveState();
    }
    public static void AddPackage(Package package)
    {
        List.Add(package);
        SaveState();
    }

    public static List<Package> GetList()
    {
        return List;
    }

    public static void SaveState()
    {
        SaveKeeper.SaveToFile(List, "Packages.json", SaveType.PACKAGES);
    }

    public static void LoadState()
    {
        if (File.Exists(Globals.SaveLocation + "Packages.json"))
        {
            List = SaveKeeper.LoadFromFile<List<Package>>("Packages.json");
        }
        else
        {
            SaveKeeper.SaveToFile(List, "Packages.json", SaveType.PACKAGES);
        }
    }
}