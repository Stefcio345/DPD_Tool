using DPD_App.Models;

namespace DPD_App;

public class ServicesXml
{
    public DeclaredValueXml? DeclaredValue { get; set; }
    public CodXml? Cod { get; set; }
    public DutyXml? Duty { get; set; }
    public DpdPickupXml? DpdPickup { get; set; }
    public SelfColXml? SelfCol { get; set; }
    public DpdFoodXml? DpdFood { get; set; }
    public GuaranteeXml? Guarantee { get; set; }

    public object? Cud { get; set; }
    public object? Rod { get; set; }
    public object? InPers { get; set; }
    public object? PrivPers { get; set; }
    public object? DpdExpress { get; set; }
    public object? Pallet { get; set; }
    public object? Dox { get; set; }
    public object? DpdLQ { get; set; }
    public object? Tires { get; set; }
    public object? TiresExport { get; set; }
    public object? DigitalLabel { get; set; }
    public object? PudoToSend { get; set; }
    public object? CarryIn { get; set; }
    public object? PudoReturn { get; set; }
    
    public ServicesXml MapServices(Services services)
    {
        //Bool services
        if (services.cud) Cud = new object();
        if (services.rod) Rod = new object();
        if (services.inPers) InPers = new object();
        if (services.privPers) PrivPers = new object();
        if (services.dpdExpress) DpdExpress = new object();
        if (services.pallet) Pallet = new object();
        if (services.dox) Dox = new object();
        if (services.dpdLQ) DpdLQ = new object();
        if (services.tires) Tires = new object();
        if (services.tiresExport) TiresExport = new object();
        if (services.digitalLabel) DigitalLabel = new object();
        if (services.pudoToSend) PudoToSend = new object();
        if (services.carryIn) CarryIn = new object();
        if (services.pudoReturn) PudoReturn = new object();
        
        //Advanced services
        if (services.declaredValue) DeclaredValue = new DeclaredValueXml(services.DeclaredValue.amount, services.DeclaredValue.currency.IsoCodeA3);
        if (services.cod) Cod = new CodXml(services.Cod.amount, services.Cod.currency.IsoCodeA3);
        if (services.dpdPickup) DpdPickup = new DpdPickupXml(services.DpdPickup.pudo);
        if (services.duty) Duty = new DutyXml(services.Duty.amount, services.Duty.currency.IsoCodeA3);
        if (services.selfCol) SelfCol = new SelfColXml(services.SelfCol.receiver);
        if (services.dpdFood) DpdFood = new DpdFoodXml(services.DpdFood.limitDate);
        if (services.guarantee) Guarantee = new GuaranteeXml(services.Guarantee.type, services.Guarantee.value);
        
        return this;
    }

}

public class DeclaredValueXml
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public DeclaredValueXml()
    {
        this.Amount = 0;
        this.Currency = "PLN";
    }
    public DeclaredValueXml(decimal amount, string currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }
}

public class CodXml
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    
    public CodXml()
    {
        this.Amount = 0;
        this.Currency = "PLN";
    }
    public CodXml(decimal amount, string currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }
}

public class DpdPickupXml
{
    public string Pudo { get; set; }

    public DpdPickupXml()
    {
        this.Pudo = "PL16738";
    }
    public DpdPickupXml(string pudo)
    {
        this.Pudo = pudo;
    }
}

public class DpdFoodXml
{
    //TODO Datetime ord strink
    public string LimitDate { get; set; }

    public DpdFoodXml()
    {
        this.LimitDate = DateTime.Now.ToString("yyyy-MM-dd");
    }
    public DpdFoodXml(DateTime limitDate)
    {
        this.LimitDate = limitDate.ToString("yyyy-MM-dd");
    }
}

public class GuaranteeXml
{
    public string? Type { get; set; }
    public string? Value { get; set; }

    public GuaranteeXml()
    {
        this.Type = null;
        this.Value = null;
    }
    public GuaranteeXml(string type, string? value)
    {
        this.Type = type;
        this.Value = value;
    }
}

public class DutyXml
{
    public decimal Amount;
    public string Currency;
    
    public DutyXml()
    {
        this.Amount = 0;
        this.Currency = "PLN";
    }
    public DutyXml(decimal amount, string? currency)
    {
        this.Amount = amount;
        this.Currency = currency;
    }
}

public class SelfColXml
{
    public string Receiver;

    public SelfColXml()
    {
        this.Receiver = "PRIV";
    }
    public SelfColXml(string receiver)
    {
        this.Receiver = receiver;
    }
}