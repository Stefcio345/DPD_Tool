using System.Security.AccessControl;
using System.Xml.Serialization;
using DPD_App.Models;

namespace DPD_App;

public class PackageService
{
    
    static Envelope result;
    static XmlSerializer envelopeSerializer = new XmlSerializer(typeof(Envelope));
    
    public static async Task GenerateWaybills(Package package, Profile profile)
    {
        //Create soap request and set data
        var newPackage = CreateGenPackageRequest(package, profile);
        
        //Call WebServices
        var webServiceResponse = await NetworkService.CallSoapWebService(profile.WsdlAddress.Address, newPackage);
        //Deserialize response
        var generatePackagesResponse = DeserializeGeneratePackagesResponse(webServiceResponse);
        
        //Detect Errors in response
        if (!PackageResponseIsValid(generatePackagesResponse)) return;
            
        //Set Waybill numbers
        for (var i = 0; i < package.Parcels.Count; i++)
        {
            package.Parcels[i].Waybill = generatePackagesResponse.Return.Packages.Package.Parcels.Parcel[i].Waybill;
            package.Parcels[i].ParcelId = generatePackagesResponse.Return.Packages.Package.Parcels.Parcel[i].ParcelId;
            package.Parcels[i].Status = generatePackagesResponse.Return.Packages.Package.Parcels.Parcel[i].Status;
        }
        
        //Generate Labels
        var newLabel = CreateGenLabelRequest(package, profile);
        //Call WebServices
        webServiceResponse = await NetworkService.CallSoapWebService(profile.WsdlAddress.Address, newLabel);
        var generateLabelsResponse = DeserializeGenerateLabelsResponse(webServiceResponse);

        //Check for errors
        if (!LabelResponseIsValid(generateLabelsResponse)) return;
        //Set labels to packages
        package.Base64Label = generateLabelsResponse.Return.DocumentData;
        
    }
    
    public static async Task GenerateProtocol(Package package, Profile profile)
    {
        //Create Protocol request
        //TODO address porotkołu
        var newProtocol = CreateGenProtocolRequest(package, profile);
        //Call webservices
        var webServiceResponse = await NetworkService.CallSoapWebService(profile.WsdlAddress.Address, newProtocol);
        //Deserialize response
        var generateProtocolResponse = DeserializeGenerateProtocolResponse(webServiceResponse);
        
        if (!ProtocolResponseIsValid(generateProtocolResponse)) return;
        package.Base64Protocol = generateProtocolResponse.Return.DocumentData;
    }

    private static GeneratePackagesNumbersV9 CreateGenPackageRequest(Package package, Profile profile)
    {
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
        newPackage.OpenUMLFeV11.Packages.Receiver = new ReceiverXml().MapAddressData(package.Receiver);
        newPackage.OpenUMLFeV11.Packages.Sender = new SenderXml().MapAddressData(package.Sender);
        //Map services
        newPackage.OpenUMLFeV11.Packages.Services = new ServicesXml().MapServices(package.Services);
        
        newPackage.OpenUMLFeV11.Packages.Ref1 = package.Ref1;
        newPackage.OpenUMLFeV11.Packages.Ref2 = package.Ref2;
        newPackage.OpenUMLFeV11.Packages.Ref3 = package.Ref3;
        newPackage.OpenUMLFeV11.Packages.PayerType = package.PayerType;
        newPackage.OpenUMLFeV11.Packages.ThirdPartyFID = package.ThirdPartyFID;

        return newPackage;
    }
    
    private static GenerateSpedLabelsV4 CreateGenLabelRequest(Package package, Profile profile)
    {
        var waybills = package.Parcels.Select(parcel => parcel.Waybill).ToList();
        if (waybills.Count == 0) throw new SoapException("GenerateSpedLabelsV4 Error" , new SoapError("No parcels to generate labels", "Package does not have any parcels"));
        var newLabel = new GenerateSpedLabelsV4(waybills!);
        newLabel.UpdateAuthData(profile);
        //Set session type
        if (package.Receiver.CountryCode != package.Sender.CountryCode) newLabel.DpdServicesParamsV1.Session.SessionType = "INTERNATIONAL";
        return newLabel;
    }
    
    private static GenerateProtocolV2 CreateGenProtocolRequest(Package package, Profile profile)
    {
        var waybills = package.Parcels.Select(parcel => parcel.Waybill).ToList();
        if (waybills.Count == 0) throw new SoapException("GenerateProtocolV2 Error" , new SoapError("No parcels to generate protocol", "Package does not have any parcels"));
        var newProtocol = new GenerateProtocolV2(waybills!, package);
        newProtocol.UpdateAuthData(profile);
        //Set session type
        if (package.Receiver.CountryCode != package.Sender.CountryCode) newProtocol.DpdServicesParamsV1.Session.SessionType = "INTERNATIONAL";
        return newProtocol;
    }

    private static GeneratePackagesNumbersV9Response DeserializeGeneratePackagesResponse(string response)
    {
        Envelope result;
        var envelopeSerializer = new XmlSerializer(typeof(Envelope));

        using var reader = new StringReader(response);
        result = (Envelope)envelopeSerializer.Deserialize(reader)!;
        //If soapError
        if (result.Body.Fault is not null) throw new SoapException("Soap Error - GeneratePackagesNumbersV9", new SoapError("Soap Exception", result.Body.Fault.Faultstring));
        if (result.Body.GeneratePackagesNumbersV9Response is null) throw new SoapException("Missing Packages Error" , new SoapError("Missing GeneratePackagesNumbersV9Response response", ""));
        return result.Body.GeneratePackagesNumbersV9Response;
    }
    
    private static GenerateSpedLabelsV4Response DeserializeGenerateLabelsResponse(string response)
    {
        //Deserialize the label from response
        using var reader = new StringReader(response);
        result = (Envelope)envelopeSerializer.Deserialize(reader)!;
        if (result.Body.Fault is not null) throw new SoapException("Soap Error - GenerateSpedLabelsV4", new SoapError("Soap Exception", result.Body.Fault.Faultstring));
        if (result.Body.GenerateSpedLabelsV4Response is null) throw new SoapException("Missing Packages Error" , new SoapError("Missing GenerateSpedLabelsV4 response", ""));
        return result.Body.GenerateSpedLabelsV4Response;
    }
    
    private static GenerateProtocolV2Response DeserializeGenerateProtocolResponse(string response)
    {
        //Deserialize the label from response
        using var reader = new StringReader(response);
        result = (Envelope)envelopeSerializer.Deserialize(reader)!;
        //if (result.Body.Fault is not null) throw new SoapException("Soap Error - GenerateProtocolV2", new SoapError(result.Body.Fault.Faultstring, result.Body.Fault.Detail.Exception.StackTrace));
        if (result.Body.Fault is not null) throw new SoapException("Soap Error - GenerateProtocolV2", new SoapError("Soap Exception", result.Body.Fault.Faultstring));
        if (result.Body.GenerateProtocolV2Response is null) throw new SoapException("Missing Packages Error" , new SoapError("Missing GenerateProtocolV2 response", ""));
        return result.Body.GenerateProtocolV2Response;
    }

    private static bool PackageResponseIsValid(GeneratePackagesNumbersV9Response response)
    {
        //If status ok Return
        if (response.Return.Status == "OK") return true;
    
        //Check packages Errors
        if (response.Return.Status == "UNSPECIFIED_ERROR") throw new SoapException("GeneratePackagesNumbersV9 - Error", new SoapError(response.Return.Status, "Unspecified error occured"));
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
    
    private static bool LabelResponseIsValid(GenerateSpedLabelsV4Response response)
    {
        //If status ok Return
        if (response.Return.Session!.StatusInfo!.Status == "OK") return true;
    
        //Check packages Errors
        if (response.Return.Session.StatusInfo.Status != "OK")
            throw new SoapException("GenerateSpedLablesV4 Error",new SoapError(response.Return.Session.StatusInfo.Status, response.Return.Session.StatusInfo.Description));

        return true;
    }
    
    private static bool ProtocolResponseIsValid(GenerateProtocolV2Response response)
    {
        //If status ok Return
        if (response.Return.Session!.StatusInfo!.Status == "OK") return true;
    
        //Check packages Errors
        if (response.Return.Session.StatusInfo.Status != "OK")
            throw new SoapException("GenerateProtocolV2 Error",new SoapError(response.Return.Session.StatusInfo.Status, response.Return.Session.StatusInfo.Description));

        return true;
    }
}