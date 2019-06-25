namespace StockGame.Infrastructure.Abstract
{
    public interface IDataReaderFactory : ISingleton<IDataReaderFactory>
    {
        IDataReader CreateDataReader<T>();
    }
}
