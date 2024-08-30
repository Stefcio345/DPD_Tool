using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DPD_App.Components.Layout;

namespace DPD_App;

public class Request
{
    public static AppSettings Settings { get; set; }
    
    public static async Task<string> CallSoapWebService(string url, SoapBody body)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("SOAPAction", url);
        
        var content = new StringContent(body.CreateSoapEnvelope(), Encoding.UTF8, "text/xml");
        if(Settings.LogRequests) Logger.Log("Request", await content.ReadAsStringAsync());

        var response = await client.PostAsync(url, content);
        var responseString = await response.Content.ReadAsStringAsync();
        if(Settings.LogRequests) Logger.Log("Response", responseString);
        return responseString;
    }
    
    public static async Task<string> SendSoapRequest(string url, string requestBody)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("SOAPAction", url);
        
        var content = new StringContent(requestBody, Encoding.UTF8, "text/xml");
        if(Settings.LogRequests) Logger.Log("Request", content.ToString());

        var response = await client.PostAsync(url, content);
        var responseString = await response.Content.ReadAsStringAsync();
        if(Settings.LogRequests) Logger.Log("Response", responseString);
        return responseString;
    }
    
    public static async Task<string> SendHttpRequest(string url)
    {
        var client = new HttpClient();
        
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        if(Settings.LogRequests) Logger.Log("Request", request.ToString());

        var response = await client.SendAsync(request);
        var responseString = await response.Content.ReadAsStringAsync();
        if(Settings.LogRequests) Logger.Log("Response", responseString);
        return responseString;
    }
}