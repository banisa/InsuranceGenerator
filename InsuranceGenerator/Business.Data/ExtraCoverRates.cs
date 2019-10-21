using System.Collections.Generic;
using InsuranceGenerator.Business.Logic;

namespace InsuranceGenerator.Business.Data
{
    public static class ExtraCoverRates
    {
        public static List<ExtraCover> ExtraCoverRateTable = new List<ExtraCover>()
        {
            new ExtraCover() {CoverName = "DreadDiseaseCover", Premium = 50},
            new ExtraCover() {CoverName = "SpouseCover", Premium = 200},
            new ExtraCover() {CoverName = "HangoverCover", Premium = 100},
        };
    }
}
