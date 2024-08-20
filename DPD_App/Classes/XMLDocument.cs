using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DPD_App;

public class XMLDocument
{
    public static string Prettify(string str)
    {
        var sb = new StringBuilder();
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t",
            NewLineChars = "\r\n",
            NewLineHandling = NewLineHandling.Replace
        };
        
        try
        {
            XElement element = XElement.Parse(str);
            using (XmlWriter writer = XmlWriter.Create(sb, settings)) {
                element.Save(writer);
            }
            return sb.ToString();
        }
        catch(System.Xml.XmlException)
        {
            return str;
        }
    }
    
    public static string CreateSoapEnvelope(string body)
    {
        var soapEnvelope = $"<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP-ENV:Header/><SOAP-ENV:Body>{body}</SOAP-ENV:Body></SOAP-ENV:Envelope>";
        return soapEnvelope;
    }
}