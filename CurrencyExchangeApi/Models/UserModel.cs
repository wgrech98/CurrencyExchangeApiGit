﻿using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeApi.Models
{
    public class UserModel
    {
        [Key]
        public int? UserId { get; set; }

        public string? UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}