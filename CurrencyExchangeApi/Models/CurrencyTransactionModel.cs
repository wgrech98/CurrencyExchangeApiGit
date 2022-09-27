namespace CurrencyExchangeApi.Models
{
    public class CurrencyTransactionModel
    {
        public string To { get; set; }

        public string From { get; set; }

        public int Amount { get; set; }

        public int result { get; set; }
    }
}
