using Business.Common;
using Business.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLibrary(this IServiceCollection services)
        {
            services.AddTransient<IFeesService, FeesService>();
            services.AddTransient<ILoanService, LoanService>();
            return services;

        }
    }
}
