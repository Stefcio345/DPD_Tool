namespace DPD_App;

public class TrackingLink
{
    public static string baselink { get; set; } =
        "https://tracktrace.dpd.com.pl/parcelDetails?typ=1";

    public static string baseGeoPost = "https://www.dpdgroup.com/pl/mydpd/my-parcels/search?lang=PL&parcelNumber=";

    public static string getTrackTraceLink(string waybill)
    {
        return baselink + "&p1=" + waybill;
    }

    public static string getGeoPostLink(string waybill)
    {
        return baseGeoPost + waybill;
    }
    
}