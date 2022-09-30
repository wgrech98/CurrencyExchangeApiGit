namespace CurrencyExchangeApi.Models.ResponseModels
{
    public class CurrencyConversionResponse
    {
        public Query? query { get; set; }

        public Info? info { get; set; }

        public string? result { get; set; }
    }

    public class Query
    {
        public string? To { get; set; }

        public string? From { get; set; }

        public string? Amount { get; set; }
    }

    public class Info
    {
        public string? rate { get; set; }
    }
}
