using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="authDataV1", Namespace="")]
public class AuthDataV1
{

    [XmlElement(ElementName = "login", Namespace = "")]
    public string Login { get; set; } = Globals.LOGIN;

    [XmlElement(ElementName = "masterFid", Namespace = "")]
    public string MasterFid { get; set; } = Globals.MASTER_FID;

    [XmlElement(ElementName = "password", Namespace = "")]
    public string Password { get; set; } = Globals.PASSWORD;
}