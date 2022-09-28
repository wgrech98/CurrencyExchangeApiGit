using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class UserTransactionDataModel
    {
        [Key]
        public int? TransactionId { get; set; }

        public UserDataModel? User { get; set; }

        public int? UserId { get; set; }

        public string? To { get; set; }

        public string? From { get; set; }

        public string? Amount { get; set; }

        public string? ConvertedAmount { get; set; }
    }
}

