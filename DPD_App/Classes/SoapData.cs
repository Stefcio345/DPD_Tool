namespace DPD_App;

public class SoapData
{
    private API_METHODS _currentMethod;
    public API_METHODS CurrentMethod 
    {
        get => _currentMethod;
        set
        {
            _currentMethod = value;
            NotifyStateChanged();
        }
    }

    private string _request;
    public string Request 
    {
        get => _request;
        set
        {
            _request = value;
            NotifyStateChanged();
        }
    }

    private string _response;

    public string Response
    {
        get => _response;
        set
        {
            _response = value;
            NotifyStateChanged();
        }
    }

    public SoapData(Action onChange)
    {
        OnChange += onChange;
        _currentMethod = API_METHODS.GeneratePackagesNumbers;
        _request = "";
        _response = "";
    }
    

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}