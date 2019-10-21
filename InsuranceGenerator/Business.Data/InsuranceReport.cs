using System.Collections.Generic;
using InsuranceGenerator.Business.Logic;

namespace InsuranceGenerator.Business.Data
{
    public class InsuranceReport
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public double BasePremium { get; set; }
        public List<ExtraCover> ExtraCovers { get; set; }
        public double MonthlyInsurance { get; set; }
    }
}
