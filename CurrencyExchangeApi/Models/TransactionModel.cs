using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchangeApi.Models
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUserModel? User { get; set; }

        public List<TransactionItemModel> OrderItems { get; set; }
    }
}

