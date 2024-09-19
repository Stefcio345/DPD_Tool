using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App;

public class PackageService
{
    public static async Task GenerateWaybills(Package package, Profile profile)
    {
        //Create soap request and set data
        var newPackage = new GeneratePackagesNumbersV9();
        //Set login credentials
        newPackage.UpdateAuthData(profile);
        newPackage.LangCode = "PL";
        newPackage.PkgNumsGenerationPolicyV1 = "ALL_OR_NOTHING";
        
        //Set Package Data
        newPackage.OpenUMLFeV11.Packages.Parcels = new List<ParcelsXml>();
        foreach (var parcel in package.Parcels)
        {
            newPackage.OpenUMLFeV11.Packages.Parcels.Add(new ParcelsXml().MapParcel(parcel));
        }
        newPackage.OpenUMLFeV11.Packages.Receiver = new ReceiverXml().MapAddressData(package.Sender);
        newPackage.OpenUMLFeV11.Packages.Sender = new SenderXml().MapAddressData(package.Receiver);
        //Map services
        newPackage.OpenUMLFeV11.Packages.Services = new ServicesXml().MapServices(package.Services);
        
        newPackage.OpenUMLFeV11.Packages.Ref1 = package.Ref1;
        newPackage.OpenUMLFeV11.Packages.Ref2 = package.Ref2;
        newPackage.OpenUMLFeV11.Packages.Ref3 = package.Ref3;
        newPackage.OpenUMLFeV11.Packages.PayerType = package.PayerType;
        newPackage.OpenUMLFeV11.Packages.ThirdPartyFID = package.ThirdPartyFID;
        
        
        //Call WebServices
        var webServiceResponse = await NetworkService.CallSoapWebService(profile.WsdlAddress.Address, newPackage);
        //Deserialize response
        var generatePackagesResponse = DeserializeGeneratePackagesResponse(webServiceResponse);
        
        
        //TODO Detect Errors in response
        if (PackageResponseIsValid(generatePackagesResponse))
        {
            //Set Waybill numbers
            for (int i = 0; i < package.Parcels.Count; i++)
            {
                package.Parcels[i].Waybill = generatePackagesResponse.Return.Packages.Package.Parcels.Parcel[i].Waybill;
                package.Parcels[i].ParcelId = generatePackagesResponse.Return.Packages.Package.Parcels.Parcel[i].ParcelId;
                package.Parcels[i].Status = generatePackagesResponse.Return.Packages.Package.Parcels.Parcel[i].Status;
            }
        }

    }

    private static GeneratePackagesNumbersV9Response DeserializeGeneratePackagesResponse(string response)
    {
        Envelope result;
        var envelopeSerializer = new XmlSerializer(typeof(Envelope));
        
        using (var reader = new StringReader(response))
        {
            result = (Envelope)envelopeSerializer.Deserialize(reader)!;
            //If soapError
            if (result.Body.Fault is not null) throw new SoapException("Soap Error", new SoapError(result.Body.Fault.Faultstring, result.Body.Fault.Detail.Exception.StackTrace));
            if (result.Body.GeneratePackagesNumbersV9Response is null) throw new SoapException("Missing Packages Error" , new SoapError("Missing GeneratePackagesNumbersV9Response response", ""));
            return result.Body.GeneratePackagesNumbersV9Response;
        }
    }

    private static bool PackageResponseIsValid(GeneratePackagesNumbersV9Response response)
    {
        //If status ok Return
        if (response.Return.Status == "OK") return true;
    
        //Check packages Errors
        if (response.Return.Packages.Package!.ValidationDetails is not null)
            throw new SoapException("Package Error", response.Return.Packages.Package.ValidationDetails.GetErrors());
        
        //Check parcels Errors
        var exception = new SoapException("Parcel Error");
        foreach (var parcel in response.Return.Packages.Package!.Parcels!.Parcel!)
        {
            if (parcel.ValidationDetails is not null)
            {
                exception.Errors.AddRange(parcel.ValidationDetails.GetErrors());
            }
        }

        if (exception.Errors.Count > 0) throw exception;
        return true;
    }
}