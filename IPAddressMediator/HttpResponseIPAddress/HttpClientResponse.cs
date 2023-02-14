namespace IPAddressMediator.HttpResponseIPAddress
{
    public class HttpClientResponse
    {
        private readonly HttpClient _httpClient;

        public HttpClientResponse(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetHttpClientResponse(string ip)
        {
            var httpResponse = await _httpClient.GetAsync("https://ip2c.org/" + ip);
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            return stringResponse;
        }

    }
}
