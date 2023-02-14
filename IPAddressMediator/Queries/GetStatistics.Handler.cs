using IPAddressMediator.Data;
using IPAddressMediator.Models;
using IPAddressMediator.Services;
using MediatR;

namespace IPAddressMediator.Queries
{
    public class GetStatisticsHandler : IRequestHandler<GetStatistics, List<StatisticsModel>>
    {
        private readonly IStatisticsService _statistics;


        public GetStatisticsHandler(IStatisticsService statistics)
        {
            _statistics = statistics;
        }

        public async Task<List<StatisticsModel>> Handle(GetStatistics twoLetterCodes, CancellationToken ct)
        {
            var result = _statistics.GetStatistics(twoLetterCodes.TwoLetterCodes);

            return result;
        }
    }
}
