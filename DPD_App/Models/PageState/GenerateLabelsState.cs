namespace DPD_App.Models;

public class GenerateLabelsState
{
    public Package package = new Package();
    public List<TrackingLinkService> TrackingLinks = new List<TrackingLinkService>();
    public bool ServicesOn = true;
    public bool DetailsOn = true;
    public bool ParcelsOn = true;
    public int ActiveMode;
    public List<SoapError> Errors = new List<SoapError>();
}