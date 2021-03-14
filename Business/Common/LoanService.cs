using System;
using Business.Common.Interfaces;
using Data.Repositories.Interfaces;

namespace Business.Common
{
    public class LoanService : ILoanService
    {
        private readonly ILoanContractRepository _loanRepository;

        public LoanService(ILoanContractRepository loanRepository )
        {
            _loanRepository = loanRepository;
        }

        public double YearlyCostPercetange()
        {
            throw new System.NotImplementedException();
        }

        public double MonthlyInterest()
        {
            var loan = _loanRepository.GetLoan();
            var roundDecimals = 10;

            // rate of interest and number of payments for monthly payments
            double rateOfInterest = Math.Round(loan.AnnualInterestRatePercentage / 1200, roundDecimals);
            double numberOfPayments = loan.Duration * 12;

            // loan amount = (interest rate * loan amount) / (1 - (1 + interest rate)^(number of payments * -1))
            return Math.Round((rateOfInterest * loan.Amount) / (1 - Math.Round(Math.Pow(1 + rateOfInterest, numberOfPayments * -1), roundDecimals)), roundDecimals);

        }

        public double TotalInterest()
        {
            var loan = _loanRepository.GetLoan();
            return MonthlyInterest() * 12 * loan.Duration - loan.Amount;
        }
    }
}
