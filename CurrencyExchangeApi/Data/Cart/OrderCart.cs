using CurrencyExchangeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeApi.Data.Cart
{
    public class OrderCart
    {
        public AppDbContext _context { get; set; }

        public string OrderCartId { get; set; }
        public List<OrderCartItem> OrderCartItems { get; set; }

        public OrderCart(AppDbContext context)
        {
            _context = context;
        }

        public static OrderCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new OrderCart(context) { OrderCartId = cartId };
        }

        public void AddItemToCart(CurrencyConversion currencyConversion)
        {
            var shoppingCartItem = _context.OrderCartItems.FirstOrDefault(n => n.CurrencyConversion.Id == currencyConversion.Id && n.OrderCartId == OrderCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new OrderCartItem()
                {
                    To = currencyConversion.To,
                    From = currencyConversion.From,
                    ConversionAmount = currencyConversion.ConversionAmount,
                    ConversionResult = currencyConversion.ConversionResult,
                    OrderCartId = OrderCartId,
                    CurrencyConversion = currencyConversion,
                    AmountItems = 1
                };

                _context.OrderCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.AmountItems++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(CurrencyConversion currencyConversion)
        {
            var orderCartItem = _context.OrderCartItems.FirstOrDefault(n => n.CurrencyConversion.Id == currencyConversion.Id && n.OrderCartId == OrderCartId);

            if (orderCartItem != null)
            {
                if (orderCartItem.AmountItems > 1)
                {
                    orderCartItem.AmountItems--;
                }
                else
                {
                    _context.OrderCartItems.Remove(orderCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<OrderCartItem> GetShoppingCartItems()
        {
            return OrderCartItems ?? (OrderCartItems = _context.OrderCartItems.Where(n => n.OrderCartId == OrderCartId).Include(n => n.CurrencyConversion).ToList());
        }

        public double GetShoppingCartTotal() => _context.OrderCartItems.Where(n => n.OrderCartId == OrderCartId).Select(n => n.CurrencyConversion.ConversionResult).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.OrderCartItems.Where(n => n.OrderCartId == OrderCartId).ToListAsync();
            _context.OrderCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}