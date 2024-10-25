using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Xml;
using System.Xml.Serialization;
using MudBlazor;

namespace DPD_App;

public class Globals
{
    public static string SaveLocation = "./Data/";

    public static List<WsdlAddress> WsdlAddresses = new List<WsdlAddress>
    {
        new WsdlAddress("https://dpdservices.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL",
            "https://dpdinfoservices.dpd.com.pl/DPDInfoServicesObjEventsService/DPDInfoServicesObjEvents?wsdl",
            "https://dpdappservices.dpd.com.pl/DPDCRXmlServicesService/DPDCRXmlServices?wsdl",
            "PROD"),
        new WsdlAddress("https://dpdservicesdemo.dpd.com.pl/DPDPackageObjServicesService/DPDPackageObjServices?WSDL",
            "",
            "https://dpdappservicesdemo.dpd.com.pl/DPDCRXmlServicesService/DPDCRXmlServices?wsdl",
            "DEMO")
    };
    
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
        new Country("Poland", "PL", "POL", Currencies.First(c => c.IsoCodeA3 == "PLN"), "02274"),
        new Country("Belgium", "BE", "BEL",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "1000"),
        new Country("Croatia", "HR", "HRV",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "10000"),
        new Country("Czech Republic", "CZ", "CZE",  Currencies.First(c => c.IsoCodeA3 == "CZK"), "10000"),
        new Country("Estonia", "EE", "EST",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "49604"),
        new Country("France", "FR", "FRA",  Currencies.First(c => c.IsoCodeA3 == "EUR"), "78000"),
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
        new Profile("Default Test", "test", "thetu4Ee", "1495","1495", WsdlAddresses.Single(a => a.Name == "DEMO"),"", "", true),
    };

    public static void SaveState()
    {
        SaveKeeper.SaveToFile(Globals.Profiles, "Profiles.json");
    }

    public static void LoadState()
    {
        if (File.Exists(Globals.SaveLocation + "Profiles.json"))
        {
            Globals.Profiles = SaveKeeper.LoadFromFile<List<Profile>>("Profiles.json");
            //TODO Add remembering choosen profile
        }
        else
        {
            SaveKeeper.SaveToFile(Globals.Profiles, "Profiles.json");
        }
    }
}

public class AppSettings
{

    public bool LogRequests { get; set; } = false;
    public bool ShortenLogs { get; set; } = true;
    public int MaxLogSize { get; set; } = 1000;
    public bool LogToConsole { get; set; } = false;
    public bool LogToFile { get; set; } = false;
    public string LogSaveLocation { get; set; } = "Logs";
    
    public bool MiniDrawer { get; set; } = false;
    
    public bool SaveLabelsToFile { get; set; } = false;
    public string LabelSaveLocation { get; set; } = "Labels";
    
    public bool SaveProtocolsToFile { get; set; } = false;
    public string ProtocolSaveLocation { get; set; } = "Protocols";
    
    public string SoapDownloadLocation { get; set; } = "SoapAPI";
    
    public bool AddressDetailsVertical { get; set; } = false;


    public void LoadFromFile()
    {
        if (File.Exists(Globals.SaveLocation + "Settings.json"))
        {
            var temp = SaveKeeper.LoadFromFile<AppSettings>("Settings.json");
            LogRequests = temp.LogRequests;
            ShortenLogs = temp.ShortenLogs;
            MaxLogSize = temp.MaxLogSize;
            LogSaveLocation = temp.LogSaveLocation;
            LogToConsole = temp.LogToConsole;
            LogToFile = temp.LogToFile;
            MiniDrawer = temp.MiniDrawer;
            SaveLabelsToFile = temp.SaveLabelsToFile;
            LabelSaveLocation = temp.LabelSaveLocation;
            SaveProtocolsToFile = temp.SaveProtocolsToFile;
            ProtocolSaveLocation = temp.ProtocolSaveLocation;
            AddressDetailsVertical = temp.AddressDetailsVertical;
            SoapDownloadLocation = temp.SoapDownloadLocation;
        }
        else
        {
            SaveKeeper.SaveToFile(this, "Settings.json");
        }
    }

    public void SaveToFile()
    {
        SaveKeeper.SaveToFile(this, "Settings.json");
    }
}

public class SaveKeeper()
{
    public static void SaveToFile<T>(T objectToSave, string filename)
    {
        var jsonString = JsonSerializer.Serialize(objectToSave, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(Globals.SaveLocation + filename, jsonString);
    }
    public static T LoadFromFile<T>(string filename)
    {
        var jsonString = File.ReadAllText(Globals.SaveLocation + filename);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}

public enum SOAP_API_METHODS
{
    GeneratePackagesNumbers,
    GenerateInternationalPackageNumbers,
    GenerateSpedLabels,
    GenerateProtocol,
    FindPostalCode,
    GenerateDomesticReturnLabel,
    GenerateReturnLabel,
    AppendParcelsToPackage,
    GetCourierOrderAvailability,
    GenerateProtocolWithDestinations,
    PackagesPickupCall,
    ImportDeliveryBusinessEvent,
    
    GetEventsForCustomer,
    MarkEventsAsProcesses,
    GetEventsForWaybill,
    
    ImportPackagesCRIN,
    ImportPackagesCROUT
}

public enum API_SYSTEM
{
    DPD_SERVICES,
    INFO_SERVICES,
    APP_SERVICES
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
public enum PrintType
{
    Label,
    Protocol,
    Custom
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
        DefaultPostalCode = defaultPostalCode;
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

public class WsdlAddress
{
    [JsonInclude]
    private string DpdServicesAddress { get; set; }
    [JsonInclude]
    private string InfoServicesAddress { get; set; }
    [JsonInclude]
    private string AppServicesAddress { get; set; }
    public string Name { get; set; }

    public WsdlAddress()
    {
        DpdServicesAddress = "";
        Name = "";
    }

    public WsdlAddress(string dpdServicesAddress, string infoServicesAddress, string appServicesAddress,  string name)
    {
        DpdServicesAddress = dpdServicesAddress;
        InfoServicesAddress = infoServicesAddress;
        AppServicesAddress = appServicesAddress;
        Name = name;
    }

    public string GetAddress(API_SYSTEM system)
    {
        return system switch
        {
            API_SYSTEM.DPD_SERVICES => DpdServicesAddress,
            API_SYSTEM.INFO_SERVICES => InfoServicesAddress,
            API_SYSTEM.APP_SERVICES => AppServicesAddress,
            _ => throw new ArgumentOutOfRangeException(nameof(system), system, null)
        };
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
    public WsdlAddress WsdlAddress { get; set; }

    public Profile()
    {
        ProfileName = "";
        Login = "";
        Password = "";
        MasterFid = "";
        FID = "";
        WidgetKey = "";
        PudoKey = "";
        WsdlAddress = null;
    }

    public Profile(string profileName, string login, string password, string masterFid, string fid, WsdlAddress wsdlAddress, string widgetKey = "", string pudoKey ="", bool isChoosen=false)
    {
        ProfileName = profileName;
        Login = login;
        Password = password;
        MasterFid = masterFid;
        FID = fid;
        WidgetKey = widgetKey;
        PudoKey = pudoKey;
        IsChoosen = isChoosen;
        WsdlAddress = wsdlAddress;
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

