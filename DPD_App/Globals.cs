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
    
    public static List<MapFilter> MapFilters = new List<MapFilter>
    {
        new MapFilter("Open late", "open_late"),
        new MapFilter("Open on Saturdays", "open_saturdays"),
        new MapFilter("Open on Sundays", "open_sundays"),
        new MapFilter("Facilitations for people with disabilities", "disabled_friendly"),
        new MapFilter("Parking", "parking"),
        new MapFilter("Reception", "direct_delivery"),
        new MapFilter("Cash on delivery", "direct_delivery_cod"),
        new MapFilter("Sending a paid shipment", "dropoff_online"),
        new MapFilter("On-site drop-off + payment and BZT", "dropoff_offline"),
        new MapFilter("Return shipment", "swap_parcel"),
        new MapFilter("DPD Food", "d_fresh"),
        new MapFilter("Fitting room", "fitting_room"),
        new MapFilter("Card payment", "card_payment"),
        new MapFilter("Return documents", "rod"),
        new MapFilter("LQ", "dpd_lq"),
        new MapFilter("Ship without labels", "digital_label"),
        new MapFilter("Parcel machines", "swip_box"),
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

public class MapFilter
{
    public bool IsActive { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public MapFilter(string name, string value)
    {
        IsActive = false;
        Name = name;
        Value= value;
    }

    public override string ToString()
    {
        return Name;
    }
}