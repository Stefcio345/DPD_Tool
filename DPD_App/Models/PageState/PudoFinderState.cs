namespace DPD_App.Models;

public class PudoFinderState
{
    public Country? SelectedCountry { get; set; } = Countries.GetDefault();
}