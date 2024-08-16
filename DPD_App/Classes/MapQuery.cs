namespace DPD_App;

public class MapQuery
{
    public string Key { get; set; }
    public Country Country { get; set; }
    public List<MapFilters> FiltersList { get; set; }

    public MapQuery(string key)
    {
        Key = key;
    }

    public override string ToString()
    {
        return $"//pudofinder.dpd.com.pl/widget?key={Key}&query={Country.IsoCodeA2}";
    }
}