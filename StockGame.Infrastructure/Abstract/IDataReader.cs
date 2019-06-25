using System;
using System.Threading.Tasks;

namespace StockGame.Infrastructure.Abstract
{
    public interface IDataReader
    {
        Task<IData> ReadDataAsync(DateTime from, DateTime to);
    }
}
