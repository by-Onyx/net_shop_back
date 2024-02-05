using net_shop_back.Entities;
using net_shop_back.Models;

namespace net_shop_back.Responses.SubgroupResponses;

public record GetAllSubgroupProductsResponse
{
    public required ManufacturerGroupModel[] ManufacturerGroupModels { get; set; }
}

public record ManufacturerGroupModel
{
    public required Manufacturer? Manufacturer { get; set; }
    public required ProductCardModel[] Products { get; set; }
    public int Count => Products.Length;
}