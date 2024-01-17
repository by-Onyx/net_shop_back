using MediatR;
using net_shop_back.Responses.ProductDescriptionsResponses;

namespace net_shop_back.Requests.ProductDescriptionsRequests;

public record PostProductDescriptionRequest : IRequest<PostProductDescriptionResponse>
{
    public required long ProductId { get; set; }
    public required string Header { get; set; }
    public required string Text { get; set; }
}