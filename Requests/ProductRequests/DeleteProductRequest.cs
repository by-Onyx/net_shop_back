using MediatR;
using net_shop_back.Responses.ProductResponses;

namespace net_shop_back.Requests.ProductRequests;

public record DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public required long ProductId { get; set; }
}