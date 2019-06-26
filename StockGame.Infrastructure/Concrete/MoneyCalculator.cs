using System.Linq;
using StockGame.Infrastructure.Abstract;

namespace StockGame.Infrastructure.Concrete
{
    public class MoneyCalculator : ICalculator
    {
        public double CalculateIncomes(double startAmount, IData data)
        {
            if (startAmount == 0)
            {
                return 0;
            }

            var firstDay = data.Rates.Keys.Min();
            var firstDayRate = data.Rates.First(s => s.Key == firstDay);

            var lastDay = data.Rates.Keys.Max();
            var lastDayRate = data.Rates.First(s => s.Key == lastDay);

            var boughtAmount = startAmount / firstDayRate.Value;
            var soldPrice = boughtAmount * lastDayRate.Value;

            var income = soldPrice - startAmount;
            return income;
        }
    }
}
