using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}