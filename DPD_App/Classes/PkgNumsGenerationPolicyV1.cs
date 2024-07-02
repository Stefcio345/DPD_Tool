namespace DPD_App;

public class PkgNumsGenerationPolicyV1: GenerateXML
{
    public string pkgNumsGenerationPolicyV1 { get; set; } = "ALL_OR_NOTHING";
    
    public string generateXML()
    {
        return
            $"<{nameof(pkgNumsGenerationPolicyV1)}>{pkgNumsGenerationPolicyV1}</{nameof(pkgNumsGenerationPolicyV1)}>";
    }
}