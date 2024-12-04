using MudBlazor;
using MudBlazor.Utilities;

public class StandardTheme : MudTheme
{
    public StandardTheme()
    {
        PaletteLight = new PaletteLight()
        {
            Primary = "#fc3f3fff",
            Error = "#ff0000ff",
            AppbarBackground = "#fb3737ff",
            Background = "#e3e3e3ff",
        };

        PaletteDark = new PaletteDark()
        {
            Primary = "#fc3f3fff",
        };

        LayoutProperties = new LayoutProperties()
        {
            DefaultBorderRadius = "7px",
        };
    }
}