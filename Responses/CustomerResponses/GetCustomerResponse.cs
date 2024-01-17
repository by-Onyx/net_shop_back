using net_shop_back.Models;

namespace net_shop_back.Responses.CustomerResponse;

public record GetCustomerResponse
{
    public required CustomerModel Customer { get; set; }
}