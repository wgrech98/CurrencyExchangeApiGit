using CurrencyExchangeApi.Data;
using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CurrencyExchangeApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private UserTransactionDataModel transaction;

        private CurrencyConversionResponseModel curTr;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayForm()
        {
            return View("Display");
        }

        [HttpPost]
        public async Task<ActionResult> ConvertCurrency(IFormCollection form)
        {
            string From = form["txtFrom"];
            string To = form["txtTo"];
            int Amount = Convert.ToInt32(form["txtAmount"]);

            ResponseHandler responseHandler = new();
            var response = await responseHandler.ConvertCurrencyResponse(From, To, Amount);

            curTr = JsonConvert.DeserializeObject<CurrencyConversionResponseModel>(response);

            //transaction.UserId = 
            transaction.To = curTr.query.To;
            transaction.From = curTr.query.From;
            transaction.Amount = curTr.query.Amount;
            transaction.ConvertedAmount = curTr.result;

            return View(transaction);
        }

        [HttpGet]
        public async Task<ActionResult> ShowUserTransactions()
        {        
                      

            return View(transaction);
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