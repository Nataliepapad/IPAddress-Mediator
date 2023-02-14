namespace IPAddressMediator.IP2CIntegration
{
    public class IP2CResponse
    {
        public string CountryName { get; }

        public string TwoLetterCode { get; }

        public string ThreeLetterCode { get; }

        public IP2CResponse(string countryName, string twoLetterCode, string threeLetterCode)
        {
            CountryName = countryName;
            TwoLetterCode = twoLetterCode;
            ThreeLetterCode = threeLetterCode;
        }
    }
}
