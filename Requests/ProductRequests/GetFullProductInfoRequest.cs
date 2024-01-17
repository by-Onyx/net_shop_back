using MediatR;
using net_shop_back.Responses.ProductResponses;

namespace net_shop_back.Requests.ProductRequests;

public class GetFullProductInfoRequest : IRequest<GetFullProductInfoResponse>
{
    public required long ProductId { get; set; }
}