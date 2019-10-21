using InsuranceGenerator.Business.Logic;

namespace InsuranceGenerator.Interfaces
{
    public interface IInsuranceRules
    {
        RiskType GetRiskType(int age);
        double GetBaseInsurancePremium(int age);
        double AddExtraCover(string SelectedCoverName);
    }
}
