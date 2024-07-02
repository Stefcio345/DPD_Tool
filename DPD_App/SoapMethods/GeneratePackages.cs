namespace DPD_App;

public class GeneratePackages: GenerateXML
{
    public Packages packages { get; set; } = new Packages();
    public PkgNumsGenerationPolicyV1 pkgNumsGenerationPolicyV1 { get; set; } = new PkgNumsGenerationPolicyV1();
    public LangCode langCode { get; set; } = new LangCode();
    public AuthDataV1 AuthDataV1 { get; set; } = new AuthDataV1();
    public string generateXML()
    {
        return "<dpd:generatePackagesNumbersV9 xmlns:dpd=\"http://dpdservices.dpd.com.pl/\">" +
               packages.generateXML() +
               pkgNumsGenerationPolicyV1.generateXML() +
               langCode.generateXML() +
               AuthDataV1.generateXML() +
            "</dpd:generatePackagesNumbersV9>";
    }
}