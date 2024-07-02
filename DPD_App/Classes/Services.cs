namespace DPD_App;

public class Services: GenerateXML
{
    public bool isDeclaredValue { get; set; } = false;
    public DeclaredValue declaredValue { get; set; }
    
    public bool isCod { get; set; } = false;
    public Cod cod { get; set; }
    
    public bool isDpdPickup { get; set; } = false;
    public DpdPickup dpdPickup { get; set; }
    
    public bool isDpdFood { get; set; } = false;
    public DpdFood dpdFood { get; set; }
    
    public bool isGuarentee { get; set; } = false;
    public Guarantee guarentee { get; set; }

    public bool rod { get; set; } = false;
    public bool inPers { get; set; } = false;
    public bool provPers { get; set; } = false;
    public bool dpdLQ { get; set; } = false;
    public bool digitalLabel { get; set; } = false;
    public bool pudoToSend { get; set; } = false;
    
    public string generateXML()
    {
        var xmlString = "<services>";
        
        if (isDeclaredValue)
        {
            xmlString += declaredValue.generateXML();
        }

        if (isCod)
        {
            xmlString += cod.generateXML();
        }
        
        if (isDpdPickup)
        {
            xmlString += dpdPickup.generateXML();
        }
        
        if (isDpdFood)
        {
            xmlString += dpdFood.generateXML();
        }
        
        if (isGuarentee)
        {
            xmlString += guarentee.generateXML();
        }
        
        if (rod)
        {
            xmlString += "<rod/>";
        }
        
        if (inPers)
        {
            xmlString += "<inPers/>";
        }
        
        if (provPers)
        {
            xmlString += "<provPers/>";
        }
        
        if (dpdLQ)
        {
            xmlString += "<dpdLQ/>";
        }

        if (digitalLabel)
        {
            xmlString += "<digitalLabel/>";
        }
        
        if (pudoToSend)
        {
            xmlString += "<pudoToSend/>";
        }

        xmlString += "</services>";

        return xmlString;
    }
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