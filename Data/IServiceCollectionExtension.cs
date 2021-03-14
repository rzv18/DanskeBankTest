using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDataLibrary(this IServiceCollection services)
        {
            services.AddTransient<IFeesConfigRepository, FeesConfigRepository>();
            services.AddTransient<ILoanContractRepository, LoanContractRepository>();
            return services;

        }
    }
}
