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
    public class GoldRatesDataReader : IDataReader
    {
        private readonly GoldRatesOptions options;
        private readonly HttpClient httpClient;

        public GoldRatesDataReader(IOptions<GoldRatesOptions> options, IHttpClientFactory httpClientFactory)
        {
            this.options = options.Value;
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IData> ReadDataAsync(DateTime from, DateTime to)
        {
            if (to - from > TimeSpan.FromDays(options.MaxDateRange))
            {
                from = to.AddDays(-options.MaxDateRange);
            }

            var url = $"{options.Url}{from:yyyy-MM-dd}/{to:yyyy-MM-dd}";
            var httpResponse = await httpClient.GetAsync(url);
            var stringMessage = await httpResponse.Content.ReadAsStringAsync();
            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot get gold rate because: {stringMessage}.");
            }

            var response = JsonConvert.DeserializeObject<IEnumerable<GoldRatesResponse>>(stringMessage);
            var data = new GoldRatesData
            {
                Name = "Gold Rates",
                Rates = response.ToDictionary(s => s.Data, s => s.Cena)
            };

            return data;
        }
    }
}
