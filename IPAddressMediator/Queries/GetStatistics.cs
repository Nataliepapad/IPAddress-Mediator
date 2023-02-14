using IPAddressMediator.Entities;
using IPAddressMediator.Models;
using MediatR;

namespace IPAddressMediator.Queries
{
    public class GetStatistics : IRequest<List<StatisticsModel>>
    {
        public string[]? TwoLetterCodes { get; }

        public GetStatistics(string[] twoLetterCodes)
        {
            TwoLetterCodes = twoLetterCodes;
        }
    }
}
