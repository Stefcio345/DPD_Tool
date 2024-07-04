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
        
        var content = new StringContent(soapString, Encoding.UTF8, "text/xml");

        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }
}