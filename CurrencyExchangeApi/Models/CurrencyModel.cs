using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class CurrencyModel
    {
        [Key]
        public int? CurrencyId { get; set; }

        public string? CurrencyName { get; set; }

        public int? CurrentRate { get; set; }
    }
}
