using System;
using System.Linq;
using InsuranceGenerator.Business.Data;
using InsuranceGenerator.Business.Logic;
using InsuranceGenerator.Interfaces;

namespace InsuranceGenerator.Business.Rules
{
    public class InsuranceRules : IInsuranceRules
    {
        public RiskType GetRiskType(int age)
        {
            if (age > 50)
                throw new Exception("The person is too old for us to insure");

            if (age < 25)
                throw new Exception("The person is far too young to insure");

            return Enumerable.Range(45, 50).Contains(age) ? RiskType.High : RiskType.Low;
        }

        public double GetBaseInsurancePremium(int age)
        {
            var premium = 0.00;
            try
            {
               premium = InsuranceRates.InsuranceRateTable.FirstOrDefault(x => x.Age == age).Premium;
            }
            catch (Exception e)
            {
                return 0.00;
            }

            return premium;
        }

        public double AddExtraCover(string SelectedCoverName)
        {
            return ExtraCoverRates.ExtraCoverRateTable.FirstOrDefault(x => x.CoverName == SelectedCoverName).Premium;
        }
    }
}
