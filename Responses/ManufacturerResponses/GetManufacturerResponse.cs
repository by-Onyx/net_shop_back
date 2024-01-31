using net_shop_back.Models;

namespace net_shop_back.Responses.ManufacturerResponses;

public record GetManufacturerResponse
{
    public required ManufacturerModel Manufacturer { get; set; }
}