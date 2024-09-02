
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
        Logger.Settings = Settings;
        LabelManager.Settings = Settings;
    }
}