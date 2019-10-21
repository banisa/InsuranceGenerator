using System.Collections.Generic;
using InsuranceGenerator.Business.Logic;

namespace InsuranceGenerator.Business.Data
{
    public static class InsuranceRates
    {
        public static List<Rate> InsuranceRateTable = new List<Rate>()
        {
            new Rate() { Age = 25, Premium = 100 },
            new Rate() { Age = 26, Premium = 105 },
            new Rate() { Age = 27, Premium = 110 },
            new Rate() { Age = 28, Premium = 115 },
            new Rate() { Age = 29, Premium = 118 },
            new Rate() { Age = 30, Premium = 122 },
            new Rate() { Age = 31, Premium = 125 },
            new Rate() { Age = 32, Premium = 129 },
            new Rate() { Age = 33, Premium = 131 },
            new Rate() { Age = 34, Premium = 135 },
            new Rate() { Age = 35, Premium = 138 },
            new Rate() { Age = 36, Premium = 142 },
            new Rate() { Age = 37, Premium = 150 },
            new Rate() { Age = 38, Premium = 160 },
            new Rate() { Age = 39, Premium = 170 },
            new Rate() { Age = 40, Premium = 185 },
            new Rate() { Age = 41, Premium = 200 },
            new Rate() { Age = 42, Premium = 250 },
            new Rate() { Age = 43, Premium = 300 },
            new Rate() { Age = 44, Premium = 350 },
            new Rate() { Age = 45, Premium = 450 },
            new Rate() { Age = 46, Premium = 600 },
            new Rate() { Age = 47, Premium = 650 },
            new Rate() { Age = 48, Premium = 800 },
            new Rate() { Age = 49, Premium = 900 },
            new Rate() { Age = 50, Premium = 1000 },
        };
    }
}
