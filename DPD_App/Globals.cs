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

public enum COUNTRIES
{
    [EnumMember(Value = "Poland")]
    PL,
    [EnumMember(Value = "SP")]
    SP,
    [EnumMember(Value = "DE")]
    DE,
    [EnumMember(Value = "BE")]
    BE,
    [EnumMember(Value = "FR")]
    FR,
}