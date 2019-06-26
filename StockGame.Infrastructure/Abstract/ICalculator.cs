namespace StockGame.Infrastructure.Abstract
{
    public interface ICalculator
    {
        double CalculateIncomes(double startAmount, IData data);
    }
}
