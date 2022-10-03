using CurrencyExchangeApi.Data;
using CurrencyExchangeApi.Data.Cart;
using CurrencyExchangeApi.Data.ViewModels;
using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Models.ResponseModels;
using CurrencyExchangeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CurrencyExchangeApi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<OrdersController> _logger;
        private readonly OrderCart _orderCart;
        private CurrencyConversionResponse curTr;
        private readonly IOrdersService _ordersService;

        public OrdersController(IMemoryCache memoryCache, ILogger<OrdersController> logger, OrderCart orderList, IOrdersService OrdersService)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _orderCart = orderList;
            _ordersService = OrdersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var cacheKey = "UserOrders";
            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out List<Order> userOrders))
            {
                userOrders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);

                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey, userOrders, cacheExpiryOptions);
            }
            return View(userOrders);
        }

        public IActionResult orderCart()
        {
            var items = _orderCart.GetShoppingCartItems();
            _orderCart.OrderCartItems = items;

            var response = new OrderCartVM()
            {
                OrderCart = _orderCart,
                OrderCartTotal = _orderCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public IActionResult AddItemToOrderCart()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToOrderCart(IFormCollection form)
        {
            string From = form["txtFrom"];
            string To = form["txtTo"];
            int Amount = Convert.ToInt32(form["txtAmount"]);

            _logger.LogInformation("Currency conversion request details: From {From} To {To} For the Amount: {Amount)", From, To, Amount);

            ResponseHandler responseHandler = new();
            var response = await responseHandler.ConvertCurrencyResponse(From, To, Amount);

            curTr = JsonConvert.DeserializeObject<CurrencyConversionResponse>(response);

            var currencyConversion = await _ordersService.StoreCurrencyConversionAsync(curTr);

            _orderCart.AddItemToCart(currencyConversion);

            return RedirectToAction(nameof(orderCart));
        }

        public async Task<IActionResult> RemoveItemFromOrderCart(int id)
        {
            var item = await _ordersService.GetOrderByIdAsync(id);

            if (item != null)
            {
                _orderCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(orderCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _orderCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

            _logger.LogInformation("An order has been made by {User} ", userEmailAddress);
            await _orderCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}

