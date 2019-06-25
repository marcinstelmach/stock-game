namespace StockGame.Infrastructure.Abstract
{
    public interface IDataReaderFactory
    {
        IDataReader CreateDataReader<T>() where T : IDataReader;
    }
}
