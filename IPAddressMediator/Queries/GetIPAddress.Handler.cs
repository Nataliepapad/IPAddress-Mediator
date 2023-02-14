using Azure;
using IPAddressMediator.HttpResponseIPAddress;
using IPAddressMediator.Models;
using MediatR;
using System.Net.Http;

namespace IPAddressMediator.Queries
{
    public class GetIPAddressHandler : IRequestHandler<GetIPAddress, IPAddressModel>
    {
        private readonly HttpClientResponse _clientResponse;
        private readonly HttpResponseConverter _responseConverter;

        public GetIPAddressHandler(HttpClientResponse clientResponse, HttpResponseConverter responseConverter)
        {
            _clientResponse = clientResponse;
            _responseConverter = responseConverter;
        }

        public async Task<IPAddressModel> Handle(GetIPAddress request, CancellationToken ct)
        {
            var httpResponse = await _clientResponse.GetHttpClientResponse(request.IP);
            var convertedModel = _responseConverter.SetHttpResponseConverter(httpResponse);

            return convertedModel;

        }
    }
}
