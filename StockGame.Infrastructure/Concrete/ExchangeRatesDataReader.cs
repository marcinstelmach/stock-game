using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StockGame.Infrastructure.Abstract;
using StockGame.Infrastructure.Models;
using StockGame.Infrastructure.Options;

namespace StockGame.Infrastructure.Concrete
{
    public class ExchangeRatesDataReader : IDataReader
    {
        private readonly ExchangeRatesOptions options;
        private readonly HttpClient httpClient;

        public ExchangeRatesDataReader(IOptions<ExchangeRatesOptions> options, IHttpClientFactory httpClientFactory)
        {
            this.options = options.Value;
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IData> ReadDataAsync(DateTime @from, DateTime to)
        {
            if (to - from > TimeSpan.FromDays(options.MaxDateRange))
            {
                from = to.AddDays(-options.MaxDateRange);
            }

            var url = $"{options.Url}USD/{from:yyyy-MM-dd}/{to:yyyy-MM-dd}";
            var httpResponse = await httpClient.GetAsync(url);
            var stringMessage = await httpResponse.Content.ReadAsStringAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot get exchange rate because: {stringMessage}.");
            }

            var response = JsonConvert.DeserializeObject<ExchangeRatesResponse>(stringMessage);
            var data = new GoldRatesData
            {
                Name = "Exchange Rates",
                Rates = response.Rates.ToDictionary(s => s.EffectiveDate.ToDateTime(), s => s.Mid)
            };

            return data;
        }
    }
}
