using System.Reflection.Metadata.Ecma335;

namespace DPD_App;

public class SoapData
{
    static int TabIndex = 0;

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

    public SoapData(Action onChange)
    {
        OnChange += onChange;
        _currentMethod = API_METHODS.GeneratePackagesNumbers;
        Title = _currentMethod.ToString();
        _request = "";
        _response = "";
        TabIndex += 1;
    }
    

    public event Action OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}