using net_shop_back.Models;

namespace net_shop_back.Responses.ProductDescriptionsResponses;

public record GetAllProductDescriptionsResponse
{
    public required ProductDescriptionModel[] ProductDescriptions { get; set; }
}