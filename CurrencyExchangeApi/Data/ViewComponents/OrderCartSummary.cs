using CurrencyExchangeApi.Data.Cart;
using Microsoft.AspNetCore.Mvc;


namespace CurrencyExchangeApi.Data.ViewComponents
{
    public class OrderCartSummary:ViewComponent
    {
        private readonly OrderCart _orderCart;
        public OrderCartSummary(OrderCart orderCart)
        {
            _orderCart = orderCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _orderCart.GetShoppingCartItems();

            return View(items.Count);
        }
    }
}
