using net_shop_back.Models;

namespace net_shop_back.Responses.ProductDescriptionsResponses;

public record GetProductDescriptionResponse
{
    public required ProductDescriptionModel ProductDescription { get; set; }
}