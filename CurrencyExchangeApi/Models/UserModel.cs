using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class UserDataModel
    {
        [Key]
        public int? UserId { get; set; }

        public string? UserName { get; set; }
    }
}