using MediatR;
using net_shop_back.Responses.ProductDescriptionsResponses;

namespace net_shop_back.Requests.ProductDescriptionsRequests;

public record PutProductDescriptionRequest : IRequest<PutProductDescriptionResponse>
{
    public long Id { get; set; }
    public required long ProductId { get; set; }
    public required string Header { get; set; }
    public required string Text { get; set; }
}