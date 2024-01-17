using MediatR;
using net_shop_back.Responses.ProductDescriptionsResponses;

namespace net_shop_back.Requests.ProductDescriptionsRequests;

public record DeleteProductDescriptionRequest : IRequest<DeleteProductDescriptionResponse>
{
    public required long ProductDescriptionId { get; set; }
}