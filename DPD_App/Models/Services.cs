namespace DPD_App.Models;

public class Services
{
    public bool declaredValue { get; set; }
    public DeclaredValueService DeclaredValue { get; set; } = new DeclaredValueService();
    public bool cod { get; set; }
    public CodService Cod { get; set; } = new CodService();
    public bool duty { get; set; }
    public DutyService Duty { get; set; } = new DutyService();
    public bool dpdPickup { get; set; }
    public DpdPickupService DpdPickup { get; set; } = new DpdPickupService();
    public bool selfCol { get; set; }
    public SelfColService SelfCol { get; set; } = new SelfColService();
    public bool dpdFood { get; set; }
    public DpdFoodService DpdFood { get; set; } = new DpdFoodService();
    public bool guarantee { get; set; }
    public GuaranteeService Guarantee { get; set; } = new GuaranteeService();

    public bool cud { get; set; }
    public bool rod { get; set; }
    public bool inPers { get; set; }
    public bool privPers { get; set; }
    public bool dpdExpress { get; set; }
    public bool pallet { get; set; }
    public bool dox { get; set; }
    public bool dpdLQ { get; set; }
    public bool tires { get; set; }
    public bool tiresExport { get; set; }
    public bool digitalLabel { get; set; }
    public bool pudoToSend { get; set; }
    public bool carryIn { get; set; }
    public bool pudoReturn { get; set; }
}

public class DeclaredValueService
{
    public decimal amount { get; set; }
    public Currency currency { get; set; }

    public DeclaredValueService()
    {
        this.amount = 0;
        this.currency = Globals.Currencies.Single(c => c.IsoCodeA3 == "PLN");
    }
    public DeclaredValueService(decimal amount, Currency currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
}

public class CodService
{
    public decimal amount { get; set; }
    public Currency currency { get; set; }
    
    public CodService()
    {
        this.amount = 0;
        this.currency = Globals.Currencies.Single(c => c.IsoCodeA3 == "PLN");
    }
    public CodService(decimal amount, Currency currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
}

public class DpdPickupService
{
    public string pudo { get; set; }

    public DpdPickupService()
    {
        this.pudo = "PL16738";
    }
    public DpdPickupService(string pudo)
    {
        this.pudo = pudo;
    }
}

public class DpdFoodService
{
    //TODO Datetime ord strink
    public DateTime limitDate { get; set; }

    public DpdFoodService()
    {
        this.limitDate = DateTime.Now;
    }
    public DpdFoodService(DateTime limitDate)
    {
        this.limitDate = limitDate;
    }
}

public class GuaranteeService
{
    public string? type { get; set; }
    public string? value { get; set; }

    public GuaranteeService()
    {
        this.type = null;
        this.value = null;
    }
    public GuaranteeService(string type, string? value)
    {
        this.type = type;
        this.value = value;
    }
}

public class DutyService
{
    public decimal amount;
    public Currency currency;
    
    public DutyService()
    {
        this.amount = 0;
        this.currency = Globals.Currencies.Single(c => c.IsoCodeA3 == "PLN");
    }
    public DutyService(decimal amount, Currency? currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
}

public class SelfColService
{
    public string receiver;

    public SelfColService()
    {
        this.receiver = "PRIV";
    }
    public SelfColService(string receiver)
    {
        this.receiver = receiver;
    }
}