using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockGame.Infrastructure.Abstract;
using StockGame.Web.Models;

namespace StockGame.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataReaderFactory dataReaderFactory;

        public HomeController(IDataReaderFactory dataReaderFactory)
        {
            this.dataReaderFactory = dataReaderFactory;
        }

        public IActionResult Index()
        {
            var model = new SelectorDataViewModel();
            return View(model);
        }

        public async Task<IActionResult> Results(SelectorDataViewModel model)
        {
            var dataReader = dataReaderFactory.CreateDataReader(model.DataType);
            var response = await dataReader.ReadDataAsync(model.From, model.To);

            var viewModel = new ResultsViewModel(model, response);
            return View(viewModel);
        }
    }
}
