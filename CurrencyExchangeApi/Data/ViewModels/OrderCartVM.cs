﻿using CurrencyExchangeApi.Data.Cart;

namespace CurrencyExchangeApi.Data.ViewModels
{
    public class OrderCartVM
    {
        public OrderCart OrderCart { get; set; }

        public double ShoppingCartTotal { get; set; }
    }
}
