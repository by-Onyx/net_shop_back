using net_shop_back.Models;

namespace net_shop_back.Responses.ProductResponses;

public record PostProductResponse
{
    public required ProductModel Product { get; set; }
}
