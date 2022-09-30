using CurrencyExchangeApi.Data;
using CurrencyExchangeApi.Data.Cart;
using CurrencyExchangeApi.Data.ViewModels;
using CurrencyExchangeApi.Models.ResponseModels;
using CurrencyExchangeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CurrencyExchangeApi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderCart _orderList;
        private readonly IOrdersService _ordersService;
        private CurrencyConversionResponse curTr;

        public OrdersController(OrderCart orderList, IOrdersService OrdersService)
        {
            _orderList = orderList;
            _ordersService = OrdersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult orderCart()
        {
            var items = _orderList.GetShoppingCartItems();
            _orderList.OrderCartItems = items;

            var response = new OrderCartVM()
            {
                OrderCart = _orderList,
                ShoppingCartTotal = _orderList.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToOrderCart(IFormCollection form)
        {
            string From = form["txtFrom"];
            string To = form["txtTo"];
            int Amount = Convert.ToInt32(form["txtAmount"]);

            ResponseHandler responseHandler = new();
            var response = await responseHandler.ConvertCurrencyResponse(From, To, Amount);

            curTr = JsonConvert.DeserializeObject<CurrencyConversionResponse>(response);

            _ordersService.StoreCurrencyConversionAsync(curTr);

            return RedirectToAction(nameof(orderCart));
        }

        public async Task<IActionResult> RemoveItemFromOrderCart(int id)
        {
            var item = await _ordersService.GetOrderByIdAsync(id);

            if (item != null)
            {
                _orderList.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(orderCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _orderList.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _orderList.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}

