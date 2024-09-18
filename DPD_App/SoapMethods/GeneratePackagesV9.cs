using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="openUMLFeV11", Namespace="")]
public class OpenUMLFeV11
{
	[XmlElement(ElementName = "packages", Namespace = "")]
	public PackagesXml Packages { get; set; } = new PackagesXml();
}

[XmlRoot(ElementName="generatePackagesNumbersV9", Namespace="http://dpdservices.dpd.com.pl/")]
public class GeneratePackagesNumbersV9: ISoapBody, IAuthData
{

	[XmlElement(ElementName = "openUMLFeV11", Namespace = "")]
	public OpenUMLFeV11 OpenUMLFeV11 { get; set; }

	[XmlElement(ElementName = "pkgNumsGenerationPolicyV1", Namespace = "")]
	public string PkgNumsGenerationPolicyV1 { get; set; }

	[XmlElement(ElementName = "langCode", Namespace = "")]
	public string LangCode { get; set; }

	[XmlElement(ElementName = "authDataV1", Namespace = "")]
	public AuthDataV1 AuthDataV1 { get; set; }

	public GeneratePackagesNumbersV9()
	{
		PkgNumsGenerationPolicyV1 = "ALL_OR_NOTHING";
		LangCode = "PL";
		AuthDataV1 = new AuthDataV1();
		OpenUMLFeV11 = new OpenUMLFeV11();
	}

	public override string ToString()
	{
		var serializer = new XmlSerializer(typeof(GeneratePackagesNumbersV9));
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
		SoapEnvelope.Body.GeneratePackagesNumbersV9 = this;
		var serializer = new XmlSerializer(typeof(Envelope));
		using(StringWriter textWriter = new StringWriter())
		{
			serializer.Serialize(textWriter, SoapEnvelope);
			return textWriter.ToString();
		}
	}
}

