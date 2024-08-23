using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace DPD_App;

public class Globals
{
    public static string SaveLocation = "./Data/";
    
    public static string WSDL_ADDRESS = "https://dpdservices.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL";
    public static string WSDL_DEMO_ADDRESS = "https://dpdservicesdemo.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL";
    
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
    
    public static List<Profile> Profiles = new List<Profile>
    {
        new Profile("Default", "test", "thetu4Ee", "1495","1495"),
    };

    public static void SaveState()
    {
        SaveKeeper.SaveToFile(Globals.Profiles, "Profiles.xml");
    }

    public static void LoadState()
    {
        if (File.Exists(Globals.SaveLocation + "Profiles.xml"))
        {
            Globals.Profiles = SaveKeeper.LoadFromFile<List<Profile>>("Profiles.xml");
            //TODO Add remembering choosen profile
        }
        else
        {
            SaveKeeper.SaveToFile(Globals.Profiles, "Profiles.xml");
        }
    }
}

public class SaveKeeper()
{
    public static void SaveToFile<T>(T objectToSave, string filename)
    {
        TextWriter writer = null;
        try
        {
            var serializer = new XmlSerializer(typeof(T));
            writer = new StreamWriter(Globals.SaveLocation + filename, false);
            serializer.Serialize(writer, objectToSave);
        }
        finally
        {
            if (writer != null)
                writer.Close();
        }

    }
    public static T LoadFromFile<T>(string filename)
    {
        TextReader reader = null;
        try
        {
            var serializer = new XmlSerializer(typeof(T));
            reader = new StreamReader(Globals.SaveLocation + filename);
            return (T)serializer.Deserialize(reader);
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }
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

public class Profile: ICloneable
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string MasterFid { get; set; }
    public string FID { get; set; }
    public string WidgetKey { get; set; }
    public string PudoKey { get; set; }
    public string ProfileName { get; set; }
    public bool IsChoosen { get; set; }

    public Profile()
    {
        ProfileName = "";
        Login = "";
        Password = "";
        MasterFid = "";
        FID = "";
        WidgetKey = "";
        PudoKey = "";
    }

    public Profile(string profileName, string login, string password, string masterFid, string fid, string widgetKey = "", string pudoKey ="")
    {
        ProfileName = profileName;
        Login = login;
        Password = password;
        MasterFid = masterFid;
        FID = fid;
        WidgetKey = widgetKey;
        PudoKey = pudoKey;
    }

    public override string ToString()
    {
        return this.ProfileName;
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}

