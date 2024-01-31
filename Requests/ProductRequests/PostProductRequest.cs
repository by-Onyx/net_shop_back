using MediatR;
using net_shop_back.Responses.ProductResponses;

namespace net_shop_back.Requests.ProductRequests;

public record PostProductRequest : IRequest<PostProductResponse>
{
    public required long SubgroupId { get; set; }
    public required long ManufacturerId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Priority { get; set; }
    public required string ShortDescription { get; set; }
    public bool? IsAvailable { get; set; } = false;
    public int? Count { get; set; } = 0;
}