using Business;
using Business.Common;
using Business.Common.Interfaces;
using Data;
using Data.Models;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DanskeBankTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddBusinessLibrary()
            .AddDataLibrary()
            .BuildServiceProvider();

            var jsonLoanRepo = new JsonRepository<LoanContract>();
            jsonLoanRepo.Write(new LoanContract
            {
                Amount = 500000,
                AnnualInterestRatePercentage = 5,
                Duration = 10,
                Id = 1
            });

            var jsonFeeRepo = new JsonRepository<FeesConfig>();
            jsonFeeRepo.Write(new FeesConfig
            {
                OneTimeFeeAmount = 10000,
                OneTimeFeePercetange = 1
            });

            //do the actual work here
            var loanService = serviceProvider.GetService<ILoanService>();
            var feeService = serviceProvider.GetService<IFeesService>();


            Console.WriteLine($"Amount:{jsonLoanRepo.GetFirst().Amount}");
            Console.WriteLine($"MonthlyInterest:{Math.Round(loanService.MonthlyInterest(), 2)}");
            Console.WriteLine($"Total interest paid:{Math.Round(loanService.TotalInterest(), 2)}");
            Console.WriteLine($"Total fee paid:{Math.Round(feeService.OneTimeAdministrationFee(), 2)}");


        }

    }
}
