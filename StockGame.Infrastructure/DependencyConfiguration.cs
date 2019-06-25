using Microsoft.Extensions.DependencyInjection;
using StockGame.Infrastructure.Abstract;
using StockGame.Infrastructure.Concrete;

namespace StockGame.Infrastructure
{
    public static class DependencyConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDataReader, ExchangeRatesDataReader>();
            services.AddScoped<IDataReader, GoldRatesDataReader>();
            services.AddScoped<IDataReader, StockExchangeDataReader>();
            services.AddSingleton<IDataReaderFactory>(HttpReaderFactory.Instance(services.BuildServiceProvider()));

            return services;
        }
    }
}
