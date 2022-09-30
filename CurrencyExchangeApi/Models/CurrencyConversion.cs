using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class CurrencyConversion
    {
        [Key]
        public int Id { get; set; }

        public string? To { get; set; }

        public string? From { get; set; }

        public double? ConversionAmount { get; set; }

        public double ConversionResult { get; set; }
    }
}
