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
    
    public static async Task<string> SendSoapRequest(string url, string requestBody)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("SOAPAction", url);
        
        var content = new StringContent(requestBody, Encoding.UTF8, "text/xml");

        var response = await client.PostAsync(url, content);
        return await response.Content.ReadAsStringAsync();
    }
    
    public static async Task<string> SendHttpRequest(string url)
    {
        var client = new HttpClient();
        
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        var response = await client.SendAsync(request);
        return await response.Content.ReadAsStringAsync();
    }
}