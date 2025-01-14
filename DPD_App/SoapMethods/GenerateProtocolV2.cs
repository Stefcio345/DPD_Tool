using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App;

[XmlRoot(ElementName="generateProtocolV2", Namespace="http://dpdservices.dpd.com.pl/")]
public class GenerateProtocolV2: ISoapBody, IAuthData { 

    [XmlElement(ElementName="dpdServicesParamsV1", Namespace="")] 
    public DpdServicesParamsV1 DpdServicesParamsV1 { get; set; } 

    [XmlElement(ElementName="outputDocFormatV1", Namespace="")] 
    public string OutputDocFormatV1 { get; set; } 

    [XmlElement(ElementName="outputDocPageFormatV1", Namespace="")] 
    public string OutputDocPageFormatV1 { get; set; } 

    [XmlElement(ElementName="authDataV1", Namespace="")] 
    public AuthDataV1 AuthDataV1 { get; set; } 
    
    public GenerateProtocolV2()
    {
        DpdServicesParamsV1 = new DpdServicesParamsV1();
        DpdServicesParamsV1.PickupAddress = new PickupAddress();
        OutputDocFormatV1 = "PDF";
        OutputDocPageFormatV1 = "LBL_PRINTER";
        AuthDataV1 = new AuthDataV1();
    }
    
    public GenerateProtocolV2(List<string> waybills, Package package)
    {
        DpdServicesParamsV1 = new DpdServicesParamsV1();
        DpdServicesParamsV1.PickupAddress = new PickupAddress().MapAddressData(package.Sender);
        if (DpdServicesParamsV1.Session.PackagesObj.Parcels != null)
        {
            DpdServicesParamsV1.Session.PackagesObj.Parcels = new List<ParcelsObjXml>();
            for (var i = 0; i < waybills.Count; i++)
            {
                DpdServicesParamsV1.Session.PackagesObj.Parcels.Add(new ParcelsObjXml()
                {
                    Waybill = waybills[i]
                });
            }
        }
        
        OutputDocFormatV1 = "PDF";
        OutputDocPageFormatV1 = "LBL_PRINTER";
        AuthDataV1 = new AuthDataV1();
    }

    public override string ToString()
    {
        var serializer = new XmlSerializer(typeof(GenerateProtocolV2));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, this);
            return textWriter.ToString();
        }
    }

    public void UpdateAuthData(string login, string password, string masterFid)
    {
        this.AuthDataV1.Login = login;
        this.AuthDataV1.Password = password;
        this.AuthDataV1.MasterFid = masterFid;
    }
    public void UpdateAuthData(Profile profile)
    {
        this.AuthDataV1.Login = profile.Login;
        this.AuthDataV1.Password = profile.Password;
        this.AuthDataV1.MasterFid = profile.MasterFid;
    }

    public string CreateSoapEnvelope()
    {
        var SoapEnvelope = new Envelope();
        SoapEnvelope.Body.GenerateProtocolV2 = this;
        var serializer = new XmlSerializer(typeof(Envelope));
        using(StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, SoapEnvelope);
            return textWriter.ToString();
        }
    }
}

[XmlRoot(ElementName="pickupAddress", Namespace="")]
public class PickupAddress
{

    [XmlElement(ElementName = "fid", Namespace = "")]
    public string? Fid { get; set; }
    
    [XmlElement(ElementName="company", Namespace="")] 
    public string Company { get; set; } = "firma nadawcy";

    [XmlElement(ElementName="name", Namespace="")] 
    public string Name { get; set; } = "imie i nazwisko nadawcy";

    [XmlElement(ElementName="address", Namespace="")] 
    public string Address { get; set; } = "adres nadawcy";

    [XmlElement(ElementName="city", Namespace="")] 
    public string City { get; set; } = "miasto nadawcy";

    [XmlElement(ElementName="countryCode", Namespace="")] 
    public string CountryCode { get; set; } = "PL"; 

    [XmlElement(ElementName="postalCode", Namespace="")] 
    public string PostalCode { get; set; } = "02274";

    [XmlElement(ElementName="phone", Namespace="")] 
    public string Phone { get; set; } = "123 123 123";

    [XmlElement(ElementName="email", Namespace="")] 
    public string Email { get; set; } = "nazwa@domena-nadawcy.pl";
    
    public PickupAddress MapAddressData(AddressData addressData)
    {
        Company = addressData.Company;
        Name = addressData.Name;
        Address = addressData.Address;
        City = addressData.City;
        CountryCode = addressData.CountryCode;
        PostalCode = addressData.PostalCode;
        Phone = addressData.Phone;
        Email = addressData.Email;
        return this;
    }
}
