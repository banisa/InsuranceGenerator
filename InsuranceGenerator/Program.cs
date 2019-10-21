using System;
using System.Collections.Generic;
using InsuranceGenerator.Business.Data;
using InsuranceGenerator.Business.Logic;
using InsuranceGenerator.Business.Rules;

namespace InsuranceGenerator
{
    class Program
    {
        private static string _firstName;
        private static string _lastName;
        private static int _age;
        private static InsuranceReport _insuranceReport;
        static void Main(string[] args)
        {
            _insuranceReport = new InsuranceReport();
            _insuranceReport.ExtraCovers = new List<ExtraCover>();
            try
            {
                Console.WriteLine("Insurance Quote Application");

                GetClientPersonalDetails();

                GetRiskType();

                _insuranceReport.Age = _age;
                _insuranceReport.FullName = $"{_firstName} {_lastName}";
                _insuranceReport.BasePremium = GetInsurancePremium();
                _insuranceReport.MonthlyInsurance += _insuranceReport.BasePremium;

                var message = $"The base insurance premium for {_insuranceReport.FullName} is R{_insuranceReport.BasePremium}";
                Console.WriteLine(message);

                ConsoleKey response;
                do
                {
                    Console.Write("Do you wish to add extras? (y/n): ");
                    response = Console.ReadKey(false).Key;   
                    if (response != ConsoleKey.Enter)
                        Console.WriteLine();

                } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                switch(response)
                {
                    case ConsoleKey.Y:
                        _insuranceReport = AddExtras(_insuranceReport);
                        ShowReport(_insuranceReport);
                        break;
                    case ConsoleKey.N:
                        ShowReport(_insuranceReport);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey(true);
        }
        
        private static void GetRiskType()
        {
            var insuranceRules = new InsuranceRules();
            insuranceRules.GetRiskType(_age);
        }

        private static double GetInsurancePremium()
        {
            var insuranceRules = new InsuranceRules();
            return insuranceRules.GetBaseInsurancePremium(_age);
        }

        private static void GetClientPersonalDetails()
        {
            try
            {
                Console.Write("Client First Name: ");
                _firstName = Console.ReadLine();

                Console.Write("Client Last Name: ");
                _lastName = Console.ReadLine();

                Console.Write("Client Age: ");
                _age = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static InsuranceReport AddExtras(InsuranceReport insuranceReport)
        {
            try
            {
                //Dread Disease Cover
                var dreadDiseaseCover = GetCover("Do you require Dread Disease Cover @ R50.00 per month?: ","DreadDiseaseCover");
                if (dreadDiseaseCover > 0.00)
                {
                    insuranceReport.ExtraCovers.Add(new ExtraCover() {CoverName = "DreadDiseaseCover", Premium = dreadDiseaseCover });
                    insuranceReport.MonthlyInsurance += dreadDiseaseCover;
                }

                //Spouse Cover
                var spouseCover = GetCover("Do you require Spouse Cover @ R200.00 per month?: ", "SpouseCover");
                if (spouseCover > 0.00)
                {
                    insuranceReport.ExtraCovers.Add(new ExtraCover() { CoverName = "SpouseCover" , Premium = spouseCover });
                    insuranceReport.MonthlyInsurance += spouseCover;
                }

                //Hangover Cover
                var hangoverCover = GetCover("Do you require Hangover Cover @ R100.00 per month: ", "HangoverCover");
                if (hangoverCover > 0.00)
                {
                    insuranceReport.ExtraCovers.Add(new ExtraCover() { CoverName = "HangoverCover", Premium = hangoverCover });
                    insuranceReport.MonthlyInsurance += hangoverCover;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return insuranceReport;
        }

        private static double GetCover(string question, string cover)
        {
            var insuranceRules = new InsuranceRules();
            ConsoleKey response;
            do
            {
                Console.Write(question);
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            switch (response)
            {
                case ConsoleKey.Y:
                    return insuranceRules.AddExtraCover(cover);
                    break;
                case ConsoleKey.N:
                    break;
            }

            return 0.00;
        }

        private static void ShowReport(InsuranceReport insuranceReport)
        {
            var message =
                $"The final insurance quote for {insuranceReport.FullName} aged {insuranceReport.Age} years of age is as follows:";
            Console.WriteLine(message);
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("Client Name: {0}", insuranceReport.FullName);
            Console.WriteLine("Client Age: {0}", insuranceReport.Age);
            Console.WriteLine("Base Premium: {0}", insuranceReport.BasePremium);

            if (insuranceReport.ExtraCovers.Count > 0)
            {
                Console.WriteLine("Selected Extras below:");
            }

            for (int i = 0; i < insuranceReport.ExtraCovers.Count; i++)
            {
                Console.WriteLine("Extra {0}: {1} an additional R{2} per month", i, insuranceReport.ExtraCovers[i].CoverName, insuranceReport.ExtraCovers[i].Premium );
            }

            Console.WriteLine("The total monthly insurance premium for {0} aged {1} is R{2}",insuranceReport.FullName, insuranceReport.Age, insuranceReport.MonthlyInsurance);
        }
    }
}
