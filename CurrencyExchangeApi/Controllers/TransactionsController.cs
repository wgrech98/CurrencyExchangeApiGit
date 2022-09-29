using CurrencyExchangeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CurrencyExchangeApi.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IMoviesService _currencyService;
        private readonly ShoppingCart _orderList;
        private readonly IOrdersService _ordersService;

        public TransactionsController(ICurrencyService currencyService, OrderList orderList, ITransactionService TransactionsService)
        {
            _currencyService = currencyService;
            _orderList = orderList;
            _transactionService = TransactionsService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _orderList.GetShoppingCartItems();
            _orderList.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _orderList,
                ShoppingCartTotal = _orderList.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _currencyService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _orderList.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _currencyService.GetMovieByIdAsync(id);

            if (item != null)
            {
                _orderList.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
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
}
