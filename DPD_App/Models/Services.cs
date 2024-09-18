namespace DPD_App.Models;

public class Services
{
    public bool declaredValue { get; set; }
    public DeclaredValue? DeclaredValue { get; set; }
    public bool cod { get; set; }
    public Cod? Cod { get; set; }
    public bool duty { get; set; }
    public Duty? Duty { get; set; }
    public bool dpdPickup { get; set; }
    public DpdPickup? DpdPickup { get; set; }
    public bool selfCol { get; set; }
    public SelfCol? SelfCol { get; set; }
    public bool dpdFood { get; set; }
    public DpdFood? DpdFood { get; set; }
    public bool guarantee { get; set; }
    public Guarantee? Guarantee { get; set; }

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