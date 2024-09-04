using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName = "authDataV1")]
public class AuthDataV1
{

    [XmlElement(ElementName = "login")] public string Login { get; set; } = "test";

    [XmlElement(ElementName = "masterFid")]
    public string MasterFid { get; set; } = "1495";

    [XmlElement(ElementName = "password")] public string Password { get; set; } = "thetu4Ee";
}