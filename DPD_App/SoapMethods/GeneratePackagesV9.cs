﻿using System.Xml.Serialization;

namespace DPD_App;

[XmlRoot(ElementName="openUMLFeV11", Namespace="")]
public class OpenUMLFeV11
{
	[XmlElement(ElementName = "packages", Namespace = "")]
	public Packages Packages { get; set; } = new Packages();
}

[XmlRoot(ElementName="generatePackagesNumbersV9", Namespace="http://dpdservices.dpd.com.pl/")]
public class GeneratePackagesNumbersV9: SoapBody
{

	[XmlElement(ElementName = "openUMLFeV11", Namespace = "")]
	public OpenUMLFeV11 OpenUMLFeV11 { get; set; } = new OpenUMLFeV11();

	[XmlElement(ElementName = "pkgNumsGenerationPolicyV1", Namespace = "")]
	public string PkgNumsGenerationPolicyV1 { get; set; } = "ALL_OR_NOTHING";

	[XmlElement(ElementName = "langCode", Namespace = "")]
	public string LangCode { get; set; } = "PL";

	[XmlElement(ElementName = "authDataV1", Namespace = "")]
	public AuthDataV1 AuthDataV1 { get; set; } = new AuthDataV1();

	public override string ToString()
	{
		var serializer = new XmlSerializer(typeof(GeneratePackagesNumbersV9));
		using(StringWriter textWriter = new StringWriter())
		{
			serializer.Serialize(textWriter, this);
			return textWriter.ToString();
		}
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

