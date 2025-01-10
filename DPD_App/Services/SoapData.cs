using DPD_App.Models;

namespace DPD_App;

public class SoapData
{
    public static AppSettings Settings { get; set; }
    
    static int TabIndex = 0;
    public bool Update = false;

    private string _title = SoapData.TabIndex.ToString();
    public string Title 
    {
        get => _title;
        set
        {
            _title = value;
            NotifyStateChanged();
        }
    }
    
    private SoapApiMethod _currentMethod;
    public SoapApiMethod CurrentMethod 
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
    
    private WsdlAddress _wsdlAddress;
    public WsdlAddress WsdlAddress
    {
        get => _wsdlAddress;
        set
        {
            _wsdlAddress = value;
            NotifyStateChanged();
        }
    }

    private string? _documentData;

    public string? DocumentData
    {
        get => _documentData;
        set
        {
            _documentData = value;
            NotifyStateChanged();
        }
    }

    public SoapData(Action onChange, Profile currentProfile)
    {
        OnChange += onChange;
        _currentMethod = Settings.DefaultSoapMethod ?? new SoapApiMethod();
        _wsdlAddress = currentProfile.WsdlAddress;
        Title = _currentMethod?.Name ?? "";
        _request = "";
        _response = "";
        TabIndex += 1;
    }
    

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}