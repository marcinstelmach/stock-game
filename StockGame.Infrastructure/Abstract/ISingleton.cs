namespace StockGame.Infrastructure.Abstract
{
    public interface ISingleton<out T> where T : class
    {
        T Instance { get; }
    }
}
