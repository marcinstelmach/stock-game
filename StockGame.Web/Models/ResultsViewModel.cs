using System.ComponentModel.DataAnnotations;
using StockGame.Infrastructure.Abstract;

namespace StockGame.Web.Models
{
    public class ResultsViewModel
    {
        public SelectorDataViewModel SelectorDataViewModel { get; set; }

        public IData Data { get; set; }

        [DataType(DataType.Currency)]
        public double Income { get; set; }

        public ResultsViewModel(SelectorDataViewModel selectorDataViewModel, IData data, double income)
        {
            SelectorDataViewModel = selectorDataViewModel;
            Data = data;
            Income = income;
        }
    }
}
