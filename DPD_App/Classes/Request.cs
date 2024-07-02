using System.Net;
using System.Text;
using System.Xml;

namespace DPD_App;

public class Request
{
    public static async Task<string> CallWebService(string url, string soapString)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("SOAPAction", url);

        var soapEnvelope = CreateSoapEnvelope(soapString);
        var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");

        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }

    private static string CreateSoapEnvelope(string body)
    {
        var soapEnvelope = $"<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"><SOAP-ENV:Header/><SOAP-ENV:Body>{body}</SOAP-ENV:Body></SOAP-ENV:Envelope>";
        return soapEnvelope;
    }
}