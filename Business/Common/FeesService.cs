using Business.Common.Interfaces;
using Data.Repositories.Interfaces;

namespace Business.Common
{
    public class FeesService : IFeesService
    {
        private readonly ILoanContractRepository _loanRepository;
        private readonly IFeesConfigRepository _feesRepository;

        public FeesService(ILoanContractRepository loanContractRepository, IFeesConfigRepository feesConfigRepository)
        {
            _loanRepository = loanContractRepository;
            _feesRepository = feesConfigRepository;
        }

        public double MonthlyAdministrativeFee()
        {
            throw new System.NotImplementedException();
        }

        public double OneTimeAdministrationFee()
        {
            var loan = _loanRepository.GetLoan();
            var fee = _feesRepository.GetFeesConfig();

            var percentageFee = fee.OneTimeFeePercetange * loan.Amount / 100;

            return percentageFee <= fee.OneTimeFeeAmount ? percentageFee : fee.OneTimeFeeAmount;
        }
    }
}
