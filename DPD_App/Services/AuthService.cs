using Microsoft.AspNetCore.Components;

namespace DPD_App;

public class AuthService
{
    private readonly NavigationManager _navigationManager;

    public AuthService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }
    
    public void AuthHostname(string hostname)
    {
        if (hostname != Globals.HostName)
        {
            _navigationManager.NavigateTo("Start");
        }
    }
    
}