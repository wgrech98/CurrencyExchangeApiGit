using CurrencyExchangeApi.Data;
using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CurrencyExchangeApi.Controllers
{
    public class CurrencyController : Controller
    {
        private TransactionModel transaction;

        private CurrencyConversionResponseModel curTr;


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

            return View(curTr);
        }

        //[HttpGet]
        //public async Task<ActionResult> ShowUserTransactions()
        //{


        //    return View(transaction);
        //}
    }
}