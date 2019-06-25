using StockGame.Infrastructure.Abstract;

namespace StockGame.Web.Models
{
    public class ResultsViewModel
    {
        public SelectorDataViewModel SelectorDataViewModel { get; set; }

        public IData Data { get; set; }

        public ResultsViewModel(SelectorDataViewModel selectorDataViewModel, IData data)
        {
            SelectorDataViewModel = selectorDataViewModel;
            Data = data;
        }
    }
}
