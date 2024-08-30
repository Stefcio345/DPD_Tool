namespace DPD_App;

public class TrackingLink
{
    public string waybill;

    public TrackingLink(string waybill)
    {
        this.waybill = waybill;
    }

    string _baselink { get; set; } =
        "https://tracktrace.dpd.com.pl/parcelDetails?typ=1";

    string _baseGeoPost = "https://www.dpdgroup.com/pl/mydpd/my-parcels/search?lang=PL&parcelNumber=";

    public string getTrackTraceLink()
    {
        return _baselink + "&p1=" + waybill;
    }

    public string getGeoPostLink()
    {
        return _baseGeoPost + waybill;
    }
    
}