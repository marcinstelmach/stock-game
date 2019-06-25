using StockGame.Infrastructure.Models;

namespace StockGame.Infrastructure.Abstract
{
    public interface IDataReaderFactory
    {
        IDataReader CreateDataReader(DataType dataType);
    }
}
