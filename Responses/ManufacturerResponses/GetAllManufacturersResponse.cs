using net_shop_back.Models;

namespace net_shop_back.Responses.ManufacturerResponses;

public record GetAllManufacturersResponse
{
    public required ManufacturerModel[] Manufacturers { get; set; }
}