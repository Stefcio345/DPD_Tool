using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DPD_App;

public class Request
{
    public static async Task<string> CallSoapWebService(string url, SoapBody body)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("SOAPAction", url);
        
        var content = new StringContent(body.CreateSoapEnvelope(), Encoding.UTF8, "text/xml");

        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }
    
}