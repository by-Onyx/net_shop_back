using net_shop_back.Models;

namespace net_shop_back.Responses.ProductResponses;

public record PutProductResponse
{
    public required ProductFullInfoModelSub Product { get; set; }
}