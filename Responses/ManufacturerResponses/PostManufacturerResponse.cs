using net_shop_back.Models;

namespace net_shop_back.Responses.ManufacturerResponses;

public record PostManufacturerResponse
{
    public required ManufacturerModel Manufacturer { get; set; }
}