using net_shop_back.Models;

namespace net_shop_back.Responses.SubgroupResponses;

public record GetAllSubgroupProductsWithoutManufacturerResponse
{
    public required ProductCardModel[] Products { get; set; }
    public int Count => Products.Length;
}