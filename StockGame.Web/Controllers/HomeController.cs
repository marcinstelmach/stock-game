using System.Diagnostics;
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

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
