using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace DPD_App.Models;

[JsonSerializable(typeof(List<Profile>))]
[JsonSerializable(typeof(List<Country>))]
[JsonSerializable(typeof(AppState))]
[JsonSourceGenerationOptions(WriteIndented = true)]
internal partial class YourJsonContext : JsonSerializerContext
{
}

public class SaveKeeper()
{
    public static void SaveToFile<T>(T objectToSave, string filename)
    {
        var jsonString = JsonSerializer.Serialize(objectToSave, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(Globals.SaveLocation + filename, jsonString);
    }
    public static T LoadFromFile<T>(string filename)
    {
        var jsonString = File.ReadAllText(Globals.SaveLocation + filename);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
    
    public static void SaveState(SaveType saveType)
    {
        switch (saveType)
        {
            case SaveType.ALL:
                Profiles.SaveState();
                Countries.SaveState();
                break;
            case SaveType.PROFILES:
                Profiles.SaveState();
                break;
            case SaveType.COUNTRIES:
                Countries.SaveState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(saveType), saveType, null);
        }
    }

    public static void LoadState()
    {
        Profiles.LoadState();
        Countries.LoadState();
    }
}

public enum SaveType
{
    ALL,
    PROFILES,
    COUNTRIES
}