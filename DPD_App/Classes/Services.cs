namespace DPD_App;

public class Services
{
    public DeclaredValue declaredValue { get; set; }
    
    public Cod cod { get; set; }
    
    public DpdPickup dpdPickup { get; set; }
    
    public DpdFood dpdFood { get; set; }
    
    public Guarantee guarentee { get; set; }

    public object rod { get; set; }
    public object inPers { get; set; }
    public object provPers { get; set; }
    public object dpdLQ { get; set; }
    public object digitalLabel { get; set; }
    public object pudoToSend { get; set; }
    
}

public class DeclaredValue: GenerateXML
{
    public double amount { get; set; }
    public string currency { get; set; }

    public string generateXML()
    {
        return $"<declaredValue>" +
               $"<{nameof(amount)}> + {amount} + </{nameof(amount)}>" +
               $"<{nameof(currency)}> + {currency} + </{nameof(currency)}>" +
               $"</declaredValue>";
    }
}

public class Cod: GenerateXML
{
    public double amount { get; set; }
    public string currency { get; set; }

    public string generateXML()
    {
        return $"<cod>" +
               $"<{nameof(amount)}> + {amount} + </{nameof(amount)}>" +
               $"<{nameof(currency)}> + {currency} + </{nameof(currency)}>" +
               $"</cod>";
    }
}

public class DpdPickup: GenerateXML
{
    public string pudo { get; set; }

    public string generateXML()
    {
        return $"<dpdPickup>" +
               $"<{nameof(pudo)}> + {pudo} + </{nameof(pudo)}>" +
               $"</dpdPickup>";
    }
}

public class DpdFood: GenerateXML
{
    public DateTime limitDate { get; set; }

    public string generateXML()
    {
        return $"<dpdPickup>" +
               $"<{nameof(limitDate)}> + {limitDate:yyyy-mm-dd} + </{nameof(limitDate)}>" +
               $"</dpdPickup>";
    }
}

public class Guarantee: GenerateXML
{
    public bool time0930 { get; set; } = false;
    public bool time1200 { get; set; } = false;
    public bool saturday { get; set; } = false;
    public bool timefixed { get; set; } = false;
    public bool b2c { get; set; } = false;
    public bool nextday { get; set; } = false;
    public bool today { get; set; } = false;
    
    public string type { get; set; }
    public string? value { get; set; }

    public string generateXML()
    {
        return $"<guarantee>" +
               $"<{nameof(type)}> + {type} + </{nameof(type)}>" +
               $"<{nameof(value)}> + {value} + </{value}>" +
               $"</guarantee>";
    }
}