using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Xml.Serialization;
using MudBlazor;

namespace DPD_App;

public class Globals
{
    public static string SaveLocation = "./Data/";
    
    public static string WSDL_ADDRESS = "https://dpdservices.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL";
    public static string WSDL_DEMO_ADDRESS = "https://dpdservicesdemo.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL";
    
    public static List<Currency> Currencies = new List<Currency>()
    {
        new Currency("PLN", "Polish Zloty", isDeclaredAmount:true, isCod:true, isDuty:true),
        new Currency("CHF","Swiss Franc", isDeclaredAmount:true, isCod:true),
        new Currency("EUR","Euro", isDeclaredAmount:true, isCod:true, isDuty:true),
        new Currency("NOK","Norwegian Krone", isDeclaredAmount:true),
        new Currency("SEK","Swedish Krona", isDeclaredAmount:true),
        new Currency("USD","United States Dollar", isDeclaredAmount:true, isDuty:true),
        new Currency("GBP","Pound sterling", isDeclaredAmount:true, isDuty:true),
        new Currency("HUF", "Hungary Forint", isDeclaredAmount:true, isCod:true),
        new Currency("CZK","Czech Koruna", isDeclaredAmount:true, isCod:true),
        new Currency("BGN", "Bulgarian Lev", isCod:true),
        new Currency("RON", "Romanian Leu", isCod:true),
        new Currency("UAH","Ukrainian hryvnia", isDuty:true),
    };
    
    public static List<Country> Countries = new List<Country>
    {
        new Country("Poland", "PL", "POL", Currencies.First(c => c.IsoCodeA3 == "PLN"), "02247"),
            new Country("Belgium", "BE", "BEL",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "1000"),
        new Country("Croatia", "HR", "HRV",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "10000"),
        new Country("Czech Republic", "CZ", "CZE",  Currencies.First(c => c.IsoCodeA3 == "CZK"), "10000"),
        new Country("Estonia", "EE", "EST",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "49604"),
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

    public static List<GuaranteeType> GuaranteeTypes = new List<GuaranteeType>()
    {
        new GuaranteeType("Delivery at 9:30", "TIME0930"),
        new GuaranteeType("Delivery at 12:00", "TIME1200"),
        new GuaranteeType("Delivery on saturday", "SATURDAY"),
        new GuaranteeType("Delivery at given hour", "TIMEFIXED"),
        new GuaranteeType("Bussiness to customer", "B2C"),
        new GuaranteeType("Delivery next day", "DPDNEXTDAY"),
        new GuaranteeType("Delivery Today", "DPDTODAY"),
        new GuaranteeType("International Guarantee", "INTER"),
    };
    
    public static List<Profile> Profiles = new List<Profile>
    {
        new Profile("Default Test", "test", "thetu4Ee", "1495","1495", "","", true),
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

public class AppSettings
{

    public bool LogRequests = false;
    
    public bool MiniDrawer = false;
    
    public bool SaveLabelsToFile = false;
    public string SaveLocation = "Labels";


    public void LoadFromFile()
    {
        if (File.Exists(Globals.SaveLocation + "Settings.xml"))
        {
            var temp = SaveKeeper.LoadFromFile<AppSettings>("Settings.xml");
            LogRequests = temp.LogRequests;
            MiniDrawer = temp.MiniDrawer;
            SaveLabelsToFile = temp.SaveLabelsToFile;
            SaveLocation = temp.SaveLocation;
        }
        else
        {
            SaveKeeper.SaveToFile(this, "Settings.xml");
        }
    }

    public void SaveToFile()
    {
        SaveKeeper.SaveToFile(this, "Settings.xml");
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

public enum LoggingType
{
    ERROR,
    REQUEST,
    RESPONSE
}

public class Country
{
    public string IsoCodeA2 { get; set; }
    public string IsoCodeA3 { get; set; }
    public string Name { get; set; }
    public Currency? Currency { get; set; }
    public string? DefaultPostalCode { get; set; }

    public Country(string name, string isoCodeA2, string isoCodeA3, Currency currency = null, string defaultPostalCode = "")
    {
        IsoCodeA2 = isoCodeA2;
        IsoCodeA3 = isoCodeA3;
        Name = name;
        Currency = currency;
        defaultPostalCode = defaultPostalCode;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class Currency
{
    public string IsoCodeA3 { get; set; }
    public string Name { get; set; }

    public bool IsCod = false;
    public bool IsDeclaredAmount = false;
    public bool IsDuty = false;

    public Currency(string isoCodeA3, string name)
    {
        IsoCodeA3 = isoCodeA3;
        Name = name;
    }

    public Currency(string isoCodeA3, string name, bool isCod = false, bool isDeclaredAmount = false, bool isDuty = false)
    {
        IsCod = isCod;
        IsDeclaredAmount = isDeclaredAmount;
        IsDuty = isDuty;
        IsoCodeA3 = isoCodeA3;
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
public class GuaranteeType
{
    public string Name;
    public string Value;

    public GuaranteeType(string name, string value)
    {
        Name = name;
        Value = value;
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

    public Profile(string profileName, string login, string password, string masterFid, string fid, string widgetKey = "", string pudoKey ="", bool isChoosen=false)
    {
        ProfileName = profileName;
        Login = login;
        Password = password;
        MasterFid = masterFid;
        FID = fid;
        WidgetKey = widgetKey;
        PudoKey = pudoKey;
        IsChoosen = isChoosen;
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

