using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchangeApi.Models
{
    public class TransactionItemModel
    {
        [Key]
        public int Id { get; set; }

        public string? To { get; set; }

        public string? From { get; set; }

        public string? Amount { get; set; }

        public string? ConvertedAmount { get; set; }

        public int? TransactionId { get; set; }

        [ForeignKey("TransactionId")]
        public TransactionModel? Transaction { get; set; }
    }
}
