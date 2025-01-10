namespace DPD_App.Models;

public class Country
{
    public string IsoCodeA2 { get; set; }
    public string IsoCodeA3 { get; set; }
    public string Name { get; set; }
    public Currency? Currency { get; set; }
    public string? DefaultPostalCode { get; set; }

    private bool _isDefault;
    public bool IsDefault
    {
        get => _isDefault;
        set
        {
            if (value)
            {
                Countries.ResetDefault();
            }
            _isDefault = value;
        }
    }


    public Country()
    {
        IsoCodeA2 = "PL";
        IsoCodeA3 = "POL";
        Name = "Poland";
        Currency = null;
        DefaultPostalCode = "02274";
    }
    public Country(string name, string isoCodeA2, string isoCodeA3, Currency currency = null!, string defaultPostalCode = "")
    {
        IsoCodeA2 = isoCodeA2;
        IsoCodeA3 = isoCodeA3;
        Name = name;
        Currency = currency;
        DefaultPostalCode = defaultPostalCode;
    }
    
    public Country(Country country)
    {
        IsoCodeA2 = country.IsoCodeA2;
        IsoCodeA3 = country.IsoCodeA3;
        Name = country.Name;
        Currency = country.Currency;
        DefaultPostalCode = country.DefaultPostalCode;
    }
    
    public void UpdateFields(Country country)
    {
        IsoCodeA2 = country.IsoCodeA2;
        IsoCodeA3 = country.IsoCodeA3;
        Name = country.Name;
        Currency = country.Currency;
        DefaultPostalCode = country.DefaultPostalCode;
    }

    public override string ToString()
    {
        return Name;
    }
}

public class Countries
{
    public static List<Country> List = new List<Country>
    {
        new Country("Poland", "PL", "POL", Globals.Currencies.First(c => c.IsoCodeA3 == "PLN"), "02274"),
        new Country("Belgium", "BE", "BEL",  Globals.Currencies.First(c => c.IsoCodeA3 == "EUR"), "1000"),
        new Country("Croatia", "HR", "HRV",  Globals.Currencies.First(c => c.IsoCodeA3 == "EUR"), "10000"),
        new Country("Czech Republic", "CZ", "CZE",  Globals.Currencies.First(c => c.IsoCodeA3 == "CZK"), "10000"),
        new Country("Estonia", "EE", "EST",  Globals.Currencies.First(c => c.IsoCodeA3 == "EUR"), "49604"),
        new Country("France", "FR", "FRA",  Globals.Currencies.First(c => c.IsoCodeA3 == "EUR"), "78000"),
    };
    
    public static void SaveState()
    {
        SaveKeeper.SaveToFile(List, "Countries.json");
    }

    public static void LoadState()
    {
        if (File.Exists(Globals.SaveLocation + "Countries.json"))
        {
            List = SaveKeeper.LoadFromFile<List<Country>>("Countries.json");
        }
        else
        {
            SaveKeeper.SaveToFile(List, "Countries.json");
        }
    }

    public static Country GetDefault()
    {
        return List[0];
    }
    
    public static Country GetByIsoAlpha2(string isoAlpha2)
    {
        return List.Single(c => c.IsoCodeA2 == isoAlpha2);
    }

    public static void ResetDefault()
    {
        List.ForEach(c => c.IsDefault = false);
    }
}