using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchangeApi.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
