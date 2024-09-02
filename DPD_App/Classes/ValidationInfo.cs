using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="ValidationInfo", Namespace="")]
public class ValidationInfo { 

    [XmlElement(ElementName="ErrorId", Namespace="")] 
    public int ErrorId { get; set; } 

    [XmlElement(ElementName="ErrorCode", Namespace="")] 
    public string ErrorCode { get; set; } 

    [XmlElement(ElementName="FieldNames", Namespace="")] 
    public object FieldNames { get; set; } 

    [XmlElement(ElementName="Info", Namespace="")] 
    public string Info { get; set; } 
}

[XmlRoot(ElementName="ValidationDetails", Namespace="")]
public class ValidationDetails { 

    [XmlElement(ElementName="ValidationInfo", Namespace="")] 
    public List<ValidationInfo> ValidationInfo { get; set; }

    public List<SoapError> GetErrors()
    {
        List<SoapError> Errors = [];
        foreach (var errorDetails in ValidationInfo)
        {
            Errors.Add(new SoapError(errorDetails.ErrorCode, errorDetails.Info));
        }
        return Errors;
    }
}