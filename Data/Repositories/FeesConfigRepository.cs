using Data.Models;
using Data.Repositories.Interfaces;

namespace Data.Repositories
{
    public class FeesConfigRepository : IFeesConfigRepository
    {
        private readonly JsonRepository<FeesConfig> _jsonRepository;

        public FeesConfigRepository()
        {
            _jsonRepository = new JsonRepository<FeesConfig>();
        }

        public FeesConfig GetFeesConfig()
        {
            return _jsonRepository.GetFirst();
        }
    }
}
