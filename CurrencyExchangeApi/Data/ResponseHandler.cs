namespace CurrencyExchangeApi.Data

{
    //Response Handler class in the Data Access Layer folder
    public class ResponseHandler
    {
        public async Task<string> ConvertCurrencyResponse(string to, string from, int amount)
        {
            var client = new HttpClient();

            //Sets request details
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.apilayer.com/fixer/convert?to={to}&from={from}&amount={amount}"),
                Headers =
            {
                { "apikey", "9z4by92V1uV1b77aRZoOrBH4FizKI5iq" }
            }

            };

            string body;

            //Gets response body
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }

        public async Task<string> GetLatestData()
        {
            var client = new HttpClient();

            //Sets request details
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.apilayer.com/fixer/convert?to=GetLatest"),

            };

            string body;

            //Gets response body
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                body = await response.Content.ReadAsStringAsync();
            }

            return body;
        }
    }
}

