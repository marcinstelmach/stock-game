using System;
using System.Threading.Tasks;
using StockGame.Infrastructure.Abstract;

namespace StockGame.Infrastructure.Concrete
{
    public class GoldRatesDataReader : IDataReader
    {
        public async Task<IData> ReadDataAsync(DateTime @from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
