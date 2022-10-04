using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchangeApi.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public string? To { get; set; }

        public string? From { get; set; }

        public double Amount { get; set; }

        public double ConversionResult { get; set; }

        [ForeignKey("CurrencyCoversionId")]
        public CurrencyConversion CurrencyConversion { get; set; }

        public int CurrencyCoversionId { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
    }
}
