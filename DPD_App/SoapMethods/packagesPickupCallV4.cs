using System.Runtime.InteropServices.JavaScript;
using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="packagesPickupCallV4", Namespace="http://dpdservices.dpd.com.pl/")]
public class PackagesPickupCallV4: ISoapBody, IAuthData
{

	[XmlElement(ElementName = "dpdPickupParamsV3", Namespace = "")]
	public DpdPickupParamsV3 DpdPickupParamsV3 { get; set; }

    [XmlElement(ElementName = "authDataV1", Namespace = "")]
    public AuthDataV1 AuthDataV1 { get; set; }

    public PackagesPickupCallV4()
    {
	    DpdPickupParamsV3 = new DpdPickupParamsV3();
	    AuthDataV1 = new AuthDataV1();
    }

    public PackagesPickupCallV4(PICKUP_OPERATION_TYPES callType)
    {
	    DpdPickupParamsV3 = new DpdPickupParamsV3(callType);
	    AuthDataV1 = new AuthDataV1();
    }


    public void UpdateAuthData(string login, string password, string masterFid)
    {
	    this.AuthDataV1.Login = login;
	    this.AuthDataV1.Password = password;
	    this.AuthDataV1.MasterFid = masterFid;
    }
    public void UpdateAuthData(Profile profile)
    {
	    this.AuthDataV1.Login = profile.Login;
	    this.AuthDataV1.Password = profile.Password;
	    this.AuthDataV1.MasterFid = profile.MasterFid;
    }

    public string CreateSoapEnvelope()
    {
	    var SoapEnvelope = new Envelope();
	    SoapEnvelope.Body.PackagesPickupCallV4 = this;
	    var serializer = new XmlSerializer(typeof(Envelope));
	    using(StringWriter textWriter = new StringWriter())
	    {
		    serializer.Serialize(textWriter, SoapEnvelope);
		    return textWriter.ToString();
	    }
    }
}

[XmlRoot(ElementName="dpdPickupParamsV3", Namespace="")]
public class DpdPickupParamsV3 { 

	// INSERT/UPDATE
    [XmlElement(ElementName="operationType", Namespace="")] 
    public PICKUP_OPERATION_TYPES OperationType { get; set; }

    [XmlElement(ElementName = "orderType", Namespace = "")]
    public ORDER_TYPE OrderType { get; set; }

    [XmlElement(ElementName="pickupCallSimplifiedDetails", Namespace="")] 
    public PickupCallSimplifiedDetails PickupCallSimplifiedDetails { get; set; }

    private DateTime? _pickupDate = null;
    [XmlElement(ElementName="pickupDate", Namespace="")] 
    public string PickupDate
    {
	    get => _pickupDate?.ToString("yyyy-MM-dd");
	    set => _pickupDate = DateTime.Parse(value);
    }

    private DateTime? _pickupTimeFrom = null;
    [XmlElement(ElementName="pickupTimeFrom", Namespace="")] 
    public string PickupTimeFrom 
    {
	    get => _pickupTimeFrom?.ToString("HH:mm");
	    set => _pickupTimeFrom = DateTime.Parse(value);
    }

    private DateTime? _pickupTimeTo = null;
    [XmlElement(ElementName="pickupTimeTo", Namespace="")] 
    public string PickupTimeTo 
    {
	    get => _pickupTimeTo?.ToString($"HH:mm");
	    set => _pickupTimeTo = DateTime.Parse(value);
    }
    
    [XmlElement(ElementName="waybillsReady", Namespace="", IsNullable = false)] 
    public string WaybillsReady { get; set; }
    
    // DELETE
    [XmlElement(ElementName="checkSum", Namespace="")] 
    public string? CheckSum { get; set; } 

    [XmlElement(ElementName="orderNumber", Namespace="")] 
    public string? OrderNumber { get; set; } 
    
    //UPDATE
    [XmlElement(ElementName = "updateMode", Namespace = "")]
    public string? UpdateMode { get; set; }

    public DpdPickupParamsV3()
    {
    }

    public DpdPickupParamsV3(PICKUP_OPERATION_TYPES type)
    {
        OperationType = type;
        switch (type)
        {
            case PICKUP_OPERATION_TYPES.INSERT:
	            OrderType = ORDER_TYPE.DOMESTIC;
	            PickupCallSimplifiedDetails = new PickupCallSimplifiedDetails();
	            _pickupDate = DateTime.Today;
	            PickupTimeFrom = "09:00";
	            PickupTimeTo = "11:00";
	            WaybillsReady = "false";
                break;
            case PICKUP_OPERATION_TYPES.CANCEL:
	            CheckSum = "XXXXXXXX";
	            OrderNumber = "XXXXXXXXXXXXX";
                break;
            case PICKUP_OPERATION_TYPES.UPDATE:
	            OrderType = ORDER_TYPE.DOMESTIC;
	            CheckSum = "XXXXXXXX";
	            OrderNumber = "XXXXXXXXXXXXX";
	            UpdateMode = "DONT_CREATE_NEW_IF_CLOSED";
	            PickupCallSimplifiedDetails = new PickupCallSimplifiedDetails();
	            _pickupDate = DateTime.Today;
	            PickupTimeFrom = "09:00";
	            PickupTimeTo = "11:00";
	            WaybillsReady = "false";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}

public enum PICKUP_OPERATION_TYPES
{
    INSERT,
    CANCEL,
    UPDATE
}

public enum ORDER_TYPE
{
    DOMESTIC,
    INTERNATIONAL,
    EXPRESS
}

public enum UPDATE_MODE
{
	DONT_CREATE_NEW_IF_CLOSED,
	CREATE_NEW_IF_CLOSED
}

[XmlRoot(ElementName="pickupCallSimplifiedDetails", Namespace="")]
public class PickupCallSimplifiedDetails
{

	[XmlElement(ElementName = "packagesParams", Namespace = "")]
	public PackagesParams PackagesParams { get; set; } = new PackagesParams();

	[XmlElement(ElementName = "pickupCustomer", Namespace = "")]
	public PickupCustomer PickupCustomer { get; set; } = new PickupCustomer();

	[XmlElement(ElementName = "pickupPayer", Namespace = "")]
	public PickupPayer PickupPayer { get; set; } = new PickupPayer();

	[XmlElement(ElementName = "pickupSender", Namespace = "")]
	public PickupSender PickupSender { get; set; } = new PickupSender();
}

[XmlRoot(ElementName="packagesParams", Namespace="")]
public class PackagesParams
{

	[XmlElement(ElementName = "dox", Namespace = "")]
	public bool Dox { get; set; } = false;

	[XmlElement(ElementName = "doxCount", Namespace = "")]
	public int DoxCount { get; set; } = 0;

	[XmlElement(ElementName = "pallet", Namespace = "")]
	public bool Pallet { get; set; } = false;

	[XmlElement(ElementName = "palletMaxHeight", Namespace = "")]
	public int PalletMaxHeight { get; set; } = 23;

	[XmlElement(ElementName = "palletMaxWeight", Namespace = "")]
	public int PalletMaxWeight { get; set; } = 23;

	[XmlElement(ElementName = "palletsCount", Namespace = "")]
	public int PalletsCount { get; set; } = 23;

	[XmlElement(ElementName="palletsWeight", Namespace="")] 
	public int PalletsWeight { get; set; } = 23;

	[XmlElement(ElementName="parcelMaxDepth", Namespace="")] 
	public int ParcelMaxDepth { get; set; } = 23;

	[XmlElement(ElementName="parcelMaxHeight", Namespace="")] 
	public int ParcelMaxHeight { get; set; } = 23;

	[XmlElement(ElementName="parcelMaxWeight", Namespace="")] 
	public int ParcelMaxWeight { get; set; } = 23;

	[XmlElement(ElementName="parcelMaxWidth", Namespace="")] 
	public int ParcelMaxWidth { get; set; } = 23;

	[XmlElement(ElementName="parcelsCount", Namespace="")] 
	public int ParcelsCount { get; set; } = 1;

	[XmlElement(ElementName="parcelsWeight", Namespace="")] 
	public double ParcelsWeight { get; set; } = 23;

	[XmlElement(ElementName = "standardParcel", Namespace = "")]
	public bool StandardParcel { get; set; } = true;
}

[XmlRoot(ElementName="pickupCustomer", Namespace="")]
public class PickupCustomer
{

	[XmlElement(ElementName = "customerFullName", Namespace = "")]
	public string CustomerFullName { get; set; } = "CustomerFullName";

	[XmlElement(ElementName = "customerName", Namespace = "")]
	public string CustomerName { get; set; } = "CustomerName";

	[XmlElement(ElementName = "customerPhone", Namespace = "")]
	public string CustomerPhone { get; set; } = "123123123";
}

[XmlRoot(ElementName="pickupPayer", Namespace="")]
public class PickupPayer
{

	[XmlElement(ElementName = "payerCostCenter", Namespace = "")]
	public string PayerCostCenter { get; set; } = "PayerCostCenter";

	[XmlElement(ElementName = "payerName", Namespace = "")]
	public string PayerName { get; set; } = "PayerName";

	[XmlElement(ElementName = "payerNumber", Namespace = "")]
	public string PayerNumber { get; set; } = "1495";
}

[XmlRoot(ElementName="pickupSender", Namespace="")]
public class PickupSender
{

	[XmlElement(ElementName = "senderAddress", Namespace = "")]
	public string SenderAddress { get; set; } = "SenderAddress";

	[XmlElement(ElementName="senderCity", Namespace="")] 
	public string SenderCity { get; set; } = "SenderCity";

	[XmlElement(ElementName="senderFullName", Namespace="")] 
	public string SenderFullName { get; set; } = "SenderFullName";

	[XmlElement(ElementName = "senderName", Namespace = "")]
	public string SenderName { get; set; } = "SenderName";

	[XmlElement(ElementName = "senderPhone", Namespace = "")]
	public string SenderPhone { get; set; } = "123123123";

	[XmlElement(ElementName = "senderPostalCode", Namespace = "")]
	public string SenderPostalCode { get; set; } = "02274";
}