using DPD_App.Models;
using DPD_App.Models.PageState;

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

    public string? CurrentPage = null;

    public SoapApiState SoapApiData { get; set; } = new SoapApiState();
    public PudoFinderState PudoFinderState { get; set; } = new PudoFinderState();
    public MyPudoApiState MyPudoApiState { get; set; } = new MyPudoApiState();
    public GenerateLabelsState GenerateLabelsState { get; set; } = new GenerateLabelsState();
    public CompareState CompareState { get; set; } = new CompareState();

    public event Action OnChange = null!;

    private void NotifyStateChanged() => OnChange?.Invoke();

    public void InitializeAppState()
    {
        this.LoadProfile();
        this.LoadSettings();
        this.LoadCountries();
    }

    public void LoadProfile()
    {
        foreach (var profile in Profiles.List)
        {
            if (profile.IsChosen)
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
        NotesService.Settings = Settings;
    }
    
    public void LoadCountries()
    {
        Settings = new AppSettings();
        Settings.LoadFromFile();
        LoggingService.Settings = Settings;
        FileService.Settings = Settings;
        SoapData.Settings = Settings;
        NotesService.Settings = Settings;
    }
}