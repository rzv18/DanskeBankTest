using Data.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class LoanContractRepository : ILoanContractRepository
    {
        private readonly JsonRepository<LoanContract> _jsonRepository;

        public LoanContractRepository()
        {
            _jsonRepository = new JsonRepository<LoanContract>();
        }

        public LoanContract GetLoan()
        {
            return _jsonRepository.GetFirst();
        }
    }
}
