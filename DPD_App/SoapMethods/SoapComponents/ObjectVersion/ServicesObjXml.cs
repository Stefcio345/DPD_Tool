using DPD_App.Models;

namespace DPD_App;

public class ServicesObjXml
{
    public DeclaredValue? declaredValue { get; set; }
    public Cod? cod { get; set; }
    public Duty? duty { get; set; }
    public DpdPickup? dpdPickup { get; set; }
    public SelfCol? selfCol { get; set; }
    public DpdFood? dpdFood { get; set; }
    public Guarantee? guarantee { get; set; }

    public object? cud { get; set; }
    public object? rod { get; set; }
    public object? inPers { get; set; }
    public object? privPers { get; set; }
    public object? dpdExpress { get; set; }
    public object? pallet { get; set; }
    public object? dox { get; set; }
    public object? dpdLQ { get; set; }
    public object? tires { get; set; }
    public object? tiresExport { get; set; }
    public object? digitalLabel { get; set; }
    public object? pudoToSend { get; set; }
    public object? carryIn { get; set; }
    public object? pudoReturn { get; set; }
    
    public ServicesObjXml MapServices(Services services)
    {
        //Bool services
        if (services.cud) cud = new object();
        if (services.rod) rod = new object();
        if (services.inPers) inPers = new object();
        if (services.privPers) privPers = new object();
        if (services.dpdExpress) dpdExpress = new object();
        if (services.pallet) pallet = new object();
        if (services.dox) dox = new object();
        if (services.dpdLQ) dpdLQ = new object();
        if (services.tires) tires = new object();
        if (services.tiresExport) tiresExport = new object();
        if (services.digitalLabel) digitalLabel = new object();
        if (services.pudoToSend) pudoToSend = new object();
        if (services.carryIn) carryIn = new object();
        if (services.pudoReturn) pudoReturn = new object();
        
        //Advanced services
        if (services.declaredValue) declaredValue = new DeclaredValue(services.DeclaredValue.amount, services.DeclaredValue.currency.IsoCodeA3);
        if (services.cod) cod = new Cod(services.Cod.amount, services.Cod.currency.IsoCodeA3);
        if (services.dpdPickup) dpdPickup = new DpdPickup(services.DpdPickup.pudo);
        if (services.duty) duty = new Duty(services.Duty.amount, services.Duty.currency.IsoCodeA3);
        if (services.selfCol) selfCol = new SelfCol(services.SelfCol.receiver);
        if (services.dpdFood) dpdFood = new DpdFood(services.DpdFood.limitDate);
        if (services.guarantee) guarantee = new Guarantee(services.Guarantee.type, services.Guarantee.value);
        
        return this;
    }

}

public class DeclaredValue
{
    public decimal amount { get; set; }
    public string currency { get; set; }

    public DeclaredValue()
    {
        this.amount = 0;
        this.currency = "PLN";
    }
    public DeclaredValue(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
}

public class Cod
{
    public decimal amount { get; set; }
    public string currency { get; set; }
    
    public Cod()
    {
        this.amount = 0;
        this.currency = "PLN";
    }
    public Cod(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
}

public class DpdPickup
{
    public string pudo { get; set; }

    public DpdPickup()
    {
        this.pudo = "PL16738";
    }
    public DpdPickup(string pudo)
    {
        this.pudo = pudo;
    }
}

public class DpdFood
{
    //TODO Datetime ord strink
    public string limitDate { get; set; }

    public DpdFood()
    {
        this.limitDate = DateTime.Now.ToString("yyyy-MM-dd");
    }
    public DpdFood(DateTime limitDate)
    {
        this.limitDate = limitDate.ToString("yyyy-MM-dd");
    }
}

public class Guarantee
{
    public string? type { get; set; }
    public string? value { get; set; }

    public Guarantee()
    {
        this.type = null;
        this.value = null;
    }
    public Guarantee(string type, string? value)
    {
        this.type = type;
        this.value = value;
    }
}

public class Duty
{
    public decimal amount;
    public string currency;
    
    public Duty()
    {
        this.amount = 0;
        this.currency = "PLN";
    }
    public Duty(decimal amount, string? currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
}

public class SelfCol
{
    public string receiver;

    public SelfCol()
    {
        this.receiver = "PRIV";
    }
    public SelfCol(string receiver)
    {
        this.receiver = receiver;
    }
}