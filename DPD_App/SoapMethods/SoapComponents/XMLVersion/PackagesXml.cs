using System.Data.SqlTypes;
using System.Xml.Serialization;
using DPD_App;

[XmlRoot(ElementName="Packages")]
public class PackagesXml
{

    [XmlElement(ElementName = "Package")] public List<PackageXml?> Package { get; set; } = [new PackageXml()];
    
    public override string ToString()
    {
        var serializer = new XmlSerializer(typeof(PackagesXml));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, this);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(textWriter.ToString());
            var text = Convert.ToBase64String(plainTextBytes);
            return text.Replace("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTE2Ij8+", "");
        }
    }
}