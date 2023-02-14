namespace IPAddressMediator.IP2CIntegration
{

    public interface IIP2CClient
    {
        Task<IP2CResponse> GetIP(string ip);
    }

    public class IP2CClient : IIP2CClient
    {
        private readonly HttpClient _httpClient;
        private readonly IResponseParser _responseParser;

        public IP2CClient(HttpClient httpClient, IResponseParser responseParser)
        {
            _httpClient = httpClient;
            _responseParser = responseParser;
        }

        public async Task<IP2CResponse> GetIP(string ip)
        {
            var responseBody = await _httpClient.GetStringAsync("https://ip2c.org/" + ip);
            var response = _responseParser.Parse(responseBody);

            return response;
        }
    }
}
