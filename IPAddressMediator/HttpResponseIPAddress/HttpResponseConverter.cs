using IPAddressMediator.Models;

namespace IPAddressMediator.HttpResponseIPAddress
{
    public class HttpResponseConverter
    {
        public IPAddressModel SetHttpResponseConverter(string response)
        {
            var responseMessage = response.Trim().Split(";");
            var model = new IPAddressModel { CountryName = responseMessage[3], TwoLetterCode = responseMessage[1], ThreeLetterCode = responseMessage[2] };

            return model;
        }
    }
}
