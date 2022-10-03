using CurrencyExchangeApi.Models;
using CurrencyExchangeApi.Models.ResponseModels;

namespace CurrencyExchangeApi.Services.Interfaces
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<OrderCartItem> items, string userId, string userEmailAddress);
        Task<CurrencyConversion> GetOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task<CurrencyConversion> StoreCurrencyConversionAsync(CurrencyConversionResponse curTr);  
    }
}

