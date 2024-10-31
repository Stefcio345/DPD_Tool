
using DPD_App.Components.Pages;
using DPD_App.Models;

namespace DPD_App;

public class AppState
{
    private Profile _currentProfile;
    public Profile CurrentProfile
    {
        get => _currentProfile;
        set
        {
            _currentProfile = value;
            NotifyStateChanged();
        }
    }
    
    private AppSettings _settings;
    public AppSettings Settings
    {
        get => _settings;
        set
        {
            _settings = value;
            NotifyStateChanged();
        }
    }

    public SoapApiState SoapApiData { get; set; } = new SoapApiState();
    public PudoFinderState PudoFinderState { get; set; } = new PudoFinderState();
    public MyPudoApiState MyPudoApiState { get; set; } = new MyPudoApiState();
    public GenerateLabelsState GenerateLabelsState { get; set; } = new GenerateLabelsState();
    public CompareState CompareState { get; set; } = new CompareState();

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public void LoadProfile()
    {
        foreach (var profile in Globals.Profiles)
        {
            if (profile.IsChoosen)
                CurrentProfile = profile;
        }

        CurrentProfile ??= new Profile();
    }
    
    public void LoadSettings()
    {
        Settings = new AppSettings();
        Settings.LoadFromFile();
        LoggingService.Settings = Settings;
        FileService.Settings = Settings;
        SoapData.Settings = Settings;
    }
}