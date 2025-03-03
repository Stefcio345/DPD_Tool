using DPD_App.Models;

namespace DPD_App;

public class Globals
{
    public static string HostName = "Start";

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

    public SoapApiMethod? DefaultSoapMethod { get; set; }
    
    public bool ImpossibleServiceCombinationsEnabled { get; set; }
    public string NoteSaveLocation { get; set; } = "Notes";


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
            DefaultSoapMethod = temp.DefaultSoapMethod;
            ImpossibleServiceCombinationsEnabled = temp.ImpossibleServiceCombinationsEnabled;
            NoteSaveLocation = temp.NoteSaveLocation;
        }
        else
        {
            SaveKeeper.SaveToFile(this, "Settings.json", SaveType.DEFAULT);
        }
    }

    public void SaveToFile()
    {
        SaveKeeper.SaveToFile(this, "Settings.json", SaveType.DEFAULT);
    }
}

public class SoapApiMethod
{
    public string Name { get; set; }
    public SOAP_API_METHODS Type { get; set; }
    public API_SYSTEM System { get; set; }
    public List<string>? Variants { get; set; }
    public string? SelectedVariant { get; set; }
    
    public SoapApiMethod(string name, SOAP_API_METHODS type, API_SYSTEM system, List<string> variants = null)
    {
        Variants = variants;
        Name = name;
        Type = type;
        System = system;
    }
    
    public SoapApiMethod()
    {
        Name = "Empty";
        Type = SOAP_API_METHODS.EMPTY;
        System = API_SYSTEM.EMPTY;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class SoapApiMethods
{
    public static List<SoapApiMethod> Methods = new List<SoapApiMethod>
    {
        new SoapApiMethod( "GeneratePackagesNumbers", SOAP_API_METHODS.GeneratePackagesNumbers, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "GenerateInternationalPackageNumbers", SOAP_API_METHODS.GenerateInternationalPackageNumbers, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "GenerateSpedLabels", SOAP_API_METHODS.GenerateSpedLabels, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "GenerateProtocol", SOAP_API_METHODS.GenerateProtocol, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "FindPostalCode", SOAP_API_METHODS.FindPostalCode, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "GenerateDomesticReturnLabel", SOAP_API_METHODS.GenerateDomesticReturnLabel, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "GenerateReturnLabel", SOAP_API_METHODS.GenerateReturnLabel, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "AppendParcelsToPackage", SOAP_API_METHODS.AppendParcelsToPackage, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "GetCourierOrderAvailability", SOAP_API_METHODS.GetCourierOrderAvailability, API_SYSTEM.DPD_SERVICES),
        new SoapApiMethod( "PackagesPickupCall", SOAP_API_METHODS.PackagesPickupCall, API_SYSTEM.DPD_SERVICES, ["INSERT", "UPDATE", "CANCEL"]),
    
        new SoapApiMethod( "GetEventsForCustomer", SOAP_API_METHODS.GetEventsForCustomer, API_SYSTEM.INFO_SERVICES),
        new SoapApiMethod( "MarkEventsAsProcesses", SOAP_API_METHODS.MarkEventsAsProcesses, API_SYSTEM.INFO_SERVICES),
        new SoapApiMethod( "GetEventsForWaybill", SOAP_API_METHODS.GetEventsForWaybill, API_SYSTEM.INFO_SERVICES),
        
        new SoapApiMethod( "ImportPackages", SOAP_API_METHODS.ImportPackages, API_SYSTEM.APP_SERVICES, ["CR-IN", "CR-OUT"]),
        
        new SoapApiMethod("Empty", SOAP_API_METHODS.EMPTY, API_SYSTEM.EMPTY)
    };
    
    public static SoapApiMethod GetSoapApiMethod(SOAP_API_METHODS type)
    {
        return Methods.FirstOrDefault(m => m.Type == type) ?? new SoapApiMethod("NOT IMPLEMENTED", SOAP_API_METHODS.GeneratePackagesNumbers, API_SYSTEM.DPD_SERVICES);
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
    PackagesPickupCall,
    
    GetEventsForCustomer,
    MarkEventsAsProcesses,
    GetEventsForWaybill,
    
    ImportPackages,
    
    EMPTY
}

public enum API_SYSTEM
{
    DPD_SERVICES,
    INFO_SERVICES,
    APP_SERVICES,
    EMPTY
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


public class Currency
{
    public string IsoCodeA3 { get; set; }
    public string Name { get; set; }

    public bool IsCod = false;
    public bool IsDeclaredAmount = false;
    public bool IsDuty = false;

    public Currency()
    {
        IsoCodeA3 = "PLN";
        Name = "Polish Złoty";
    }
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
        return $"({IsoCodeA3}) {Name}";
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
    public string DpdServicesAddress { get; set; }
    public string InfoServicesAddress { get; set; }
    public string AppServicesAddress { get; set; }
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

