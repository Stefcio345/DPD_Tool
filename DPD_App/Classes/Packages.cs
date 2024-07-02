namespace DPD_App;

public class Packages : GenerateXML
{
    public List<Parcel> Parcels = [new Parcel()];
    public string payerType { get; set; } = "THIRD_PARTY";
    public string? thirdPartyFID { get; set; } = Globals.MASTER_FID;
    public Sender sender { get; set; } = new Sender();
    public Receiver receiver { get; set; } = new Receiver();
    public string? ref1 { get; set; } = "ref1_abc";
    public string? ref2 { get; set; } = "ref2_def";
    public string? ref3 { get; set; } = "ref3_ghi";
    public Services services { get; set; } = new Services();
    public string generateXML()
    {
        return "<openUMLFeV11>" +
               "<packages>" +
               GenerateXMLFromParcels() +
               sender.generateXML() +
               receiver.generateXML() +
               $"<{nameof(payerType)}>{payerType}</{nameof(payerType)}>" +
               $"<{nameof(thirdPartyFID)}>{thirdPartyFID}</{nameof(thirdPartyFID)}>" +
               $"<{nameof(ref1)}>{ref1}</{nameof(ref1)}>" +
               $"<{nameof(ref2)}>{ref2}</{nameof(ref2)}>" +
               $"<{nameof(ref3)}>{ref3}</{nameof(ref3)}>" +
               services.generateXML() +
               "</packages>" +
               "</openUMLFeV11>";
    }

    private string GenerateXMLFromParcels()
    {
        return Parcels.Aggregate("", (current, parcel) => current + parcel.generateXML());
    }
}