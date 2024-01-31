using MediatR;
using net_shop_back.Responses.ProductResponses;

namespace net_shop_back.Requests.ProductRequests;

public record ChangeProductPriorityRequest : IRequest<ChangeProductPriorityResponse>
{
    public long ProductId { get; set; }
    public required int Priority { get; set; }
}