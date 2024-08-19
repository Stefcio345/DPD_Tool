using System.Runtime.Serialization;

namespace DPD_App;

public class Globals
{
    public static string WSDL_ADDRESS = "https://dpdservices.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL";
    public static string WSDL_DEMO_ADDRESS = "https://dpdservicesdemo.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL";

    public static string LOGIN = "test";
    public static string PASSWORD = "thetu4Ee";
    public static string MASTER_FID = "1495";

    public static string MAP_KEY = "";
    
    public static List<Country> Countries = new List<Country>
    {
        new Country("Poland", "PL", "POL"),
        new Country("Belgium", "BE", "BEL"),
        new Country("Croatia", "HR", "HRV"),
        new Country("Czech Republic", "CZ", "CZE"),
        new Country("Denmark", "DK", "DNK"),
        new Country("Estonia", "EE", "EST"),
    };
}

public enum API_METHODS
{
    GeneratePackagesNumbers,
    GenerateInternationalPackageNumbers,
    GenerateSpedLabels,
    GenerateProtocol,
    FindPostalCode,
    GenerateReturnPackages,
    GenerateDomesticReturnLabel,
    GenerateReturnLabel,
    GenerateShipment,
    AppendParcelsToPackage,
    GetCourierOderAvailability,
    GenerateProtocolsWithDestinations,
    PackagesPickupCall,
    ImportDeliveryBusinessEvent
}

public enum CallTypes
{
    LABEL
}

public class Country
{
    public string IsoCodeA2 { get; set; }
    public string IsoCodeA3 { get; set; }
    public string Name { get; set; }

    public Country(string name, string isoCodeA2, string isoCodeA3)
    {
        IsoCodeA2 = isoCodeA2;
        IsoCodeA3 = isoCodeA3;
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}