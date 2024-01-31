using net_shop_back.Models;

namespace net_shop_back.Responses.ProductResponses;

public record ChangeProductPriorityResponse
{
    public required ProductModelWithPhoto Product { get; set; }
}