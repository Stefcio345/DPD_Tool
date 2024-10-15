namespace DPD_App.Models;

public class PudoFinderState
{
    public Country? SelectedCountry { get; set; } = Globals.Countries.First(c => c.IsoCodeA2 == "PL");
}