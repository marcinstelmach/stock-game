using Microsoft.AspNetCore.Mvc;
using StockGame.Infrastructure.Abstract;
using StockGame.Infrastructure.Concrete;
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
            var factory = dataReaderFactory.CreateDataReader<ExchangeRatesDataReader>();
            var model = new SelectorDataViewModel();
            return View(model);
        }

        public IActionResult Results(SelectorDataViewModel model)
        {
            return Ok();
        }
    }
}
