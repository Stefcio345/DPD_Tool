namespace DPD_App;

public class Parcel: GenerateXML
{
    public string? content { get; set; } = "Zawartość";
    public string? customerData1 { get; set; } = "Uwagi dla kuriera 1";
    public string? customerData2 { get; set; } = "Uwagi dla kuriera 2";
    public string? customerData3 { get; set; } = "Uwagi dla kuriera 3";
    public double? sizeX { get; set; } = 10;
    public double? sizeY { get; set; } = 10;
    public double? sizeZ { get; set; } = 10;
    public double weight { get; set; } = 10;
    public double? weightAdr { get; set; } = null;
    public string generateXML()
    {
        return $"<parcels>" +
               $"<{nameof(content)}>{content}</{nameof(content)}>" +
               $"<{nameof(customerData1)}>{customerData1}</{nameof(customerData1)}>" +
               $"<{nameof(customerData2)}>{customerData2}</{nameof(customerData2)}>" +
               $"<{nameof(customerData3)}>{customerData3}</{nameof(customerData3)}>" +
               $"<{nameof(sizeX)}>{sizeX}</{nameof(sizeX)}>" +
               $"<{nameof(sizeY)}>{sizeY}</{nameof(sizeY)}>" +
               $"<{nameof(sizeZ)}>{sizeZ}</{nameof(sizeZ)}>" +
               $"<{nameof(weight)}>{weight}</{nameof(weight)}>" +
               $"<{nameof(weightAdr)}>{weightAdr}</{nameof(weightAdr)}>" +
               $"</parcels>";
    }
}