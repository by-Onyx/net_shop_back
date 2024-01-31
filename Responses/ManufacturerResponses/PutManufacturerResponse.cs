using net_shop_back.Entities;
using net_shop_back.Models;

namespace net_shop_back.Responses.ManufacturerResponses;

public record PutManufacturerResponse
{
    public required ManufacturerModel Manufacturer { get; set; }
}