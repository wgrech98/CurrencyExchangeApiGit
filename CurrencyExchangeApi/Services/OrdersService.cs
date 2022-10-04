using CurrencyExchangeApi.Data;
using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Models.ResponseModels;
using CurrencyExchangeApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchangeApi.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.CurrencyConversion).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task<CurrencyConversion> GetOrderByIdAsync(int id)
        {
            var CurrencyConversionDetails = await _context.CurrenciesConversion.FirstOrDefaultAsync(n => n.Id == id);

            return CurrencyConversionDetails;
        }

        public async Task<CurrencyConversion> StoreCurrencyConversionAsync(CurrencyConversionResponse curTr)
        {
            var orderItem = new CurrencyConversion()
            {
                From = curTr.query.From,
                To = curTr.query.To,
                ConversionAmount = Double.Parse(curTr.query.Amount),
                ConversionResult = Double.Parse(curTr.result)
            };

            await _context.CurrenciesConversion.AddAsync(orderItem);

            await _context.SaveChangesAsync();

            return orderItem;
        }

        public async Task StoreOrderAsync(List<OrderCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    CurrencyCoversionId = item.CurrencyConversion.Id,
                    OrderId = order.Id,
                    From = item.CurrencyConversion.From,
                    To = item.CurrencyConversion.To,
                    Amount = item.CurrencyConversion.ConversionAmount,
                    ConversionResult = item.CurrencyConversion.ConversionResult
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
