using System.Reflection.Metadata.Ecma335;

namespace DPD_App;

public class SoapData
{
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
    
    private SOAP_API_METHODS _currentMethod;
    public SOAP_API_METHODS CurrentMethod 
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

    private API_SYSTEM _currentSystem;
    public API_SYSTEM CurrentSystem
    {
        get => _currentSystem;
        set
        {
            _currentSystem = value;
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
        _currentMethod = SOAP_API_METHODS.GeneratePackagesNumbers;
        _currentSystem = API_SYSTEM.DPD_SERVICES;
        _wsdlAddress = currentProfile.WsdlAddress;
        Title = _currentMethod.ToString();
        _request = "";
        _response = "";
        TabIndex += 1;
    }
    

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}