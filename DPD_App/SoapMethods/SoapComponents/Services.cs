namespace DPD_App;

public class Services
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