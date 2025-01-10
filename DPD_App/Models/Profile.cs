using System.Text.Json.Serialization;

namespace DPD_App.Models;

[JsonSerializable(typeof(Profiles))]
[JsonSourceGenerationOptions(WriteIndented = true)]
public class Profile: ICloneable
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string MasterFid { get; set; }
    public string Channel { get; set; }
    public string FID { get; set; }
    public string WidgetKey { get; set; }
    public string PudoKey { get; set; }
    public string ProfileName { get; set; }
    public bool IsChosen { get; set; }
    public WsdlAddress WsdlAddress { get; set; }

    public Profile()
    {
        ProfileName = "";
        Login = "";
        Password = "";
        MasterFid = "";
        Channel = "";
        FID = "";
        WidgetKey = "";
        PudoKey = "";
        WsdlAddress = Globals.WsdlAddresses.Single(a => a.Name == "DEMO");
    }

    public Profile(string profileName, string login, string password, string masterFid, string channel, string fid, WsdlAddress wsdlAddress, string widgetKey = "", string pudoKey ="", bool isChosen=false)
    {
        ProfileName = profileName;
        Login = login;
        Password = password;
        MasterFid = masterFid;
        Channel = channel;
        FID = fid;
        WidgetKey = widgetKey;
        PudoKey = pudoKey;
        IsChosen = isChosen;
        WsdlAddress = wsdlAddress;
    }

    public override string ToString()
    {
        return ProfileName;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class Profiles
{
    public static List<Profile> List =
    [
        new Profile("Default Test", "test", "thetu4Ee", "1495", "1495", "1495",
            Globals.WsdlAddresses.Single(a => a.Name == "DEMO"), "", "", true)
    ];
    
    public static void SaveState()
    {
        SaveKeeper.SaveToFile(List, "Profiles.json");
    }

    public static void LoadState()
    {
        if (File.Exists(Globals.SaveLocation + "Profiles.json"))
        {
            List = SaveKeeper.LoadFromFile<List<Profile>>("Profiles.json");
        }
        else
        {
            SaveKeeper.SaveToFile(List, "Profiles.json");
        }
    }
}