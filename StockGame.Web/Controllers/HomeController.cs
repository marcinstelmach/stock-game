using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockGame.Infrastructure.Abstract;
using StockGame.Web.Models;

namespace StockGame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataReaderFactory dataReaderFactory;
        private readonly ICalculator calculator;

        public HomeController(IDataReaderFactory dataReaderFactory, ICalculator calculator)
        {
            this.dataReaderFactory = dataReaderFactory;
            this.calculator = calculator;
        }

        public IActionResult Index()
        {
            var model = new SelectorDataViewModel();
            return View(model);
        }

        public async Task<IActionResult> Results(SelectorDataViewModel model)
        {
            var dataReader = dataReaderFactory.CreateDataReader(model.DataType);
            var data = await dataReader.ReadDataAsync(model.From, model.To);

            var income = calculator.CalculateIncomes(model.StartAmount, data);

            var viewModel = new ResultsViewModel(model, data, income);
            return View(viewModel);
        }
    }
}
