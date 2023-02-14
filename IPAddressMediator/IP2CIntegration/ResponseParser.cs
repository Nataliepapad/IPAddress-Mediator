namespace IPAddressMediator.IP2CIntegration
{
    public interface IResponseParser
    {
        IP2CResponse Parse(string response);
    }

    public class ResponseParser : IResponseParser
    {
        public IP2CResponse Parse(string response)
        {
            var parts = response.Trim().Split(";");
            var model = new IP2CResponse(countryName: parts[3], twoLetterCode: parts[1], threeLetterCode: parts[2]);

            return model;
        }
    }
}
