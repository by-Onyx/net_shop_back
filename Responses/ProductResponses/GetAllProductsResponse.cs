using net_shop_back.Models;

namespace net_shop_back.Responses.ProductResponses;

public record GetAllProductsResponse
{
    public required ProductModel[] Products { get; set; }
}