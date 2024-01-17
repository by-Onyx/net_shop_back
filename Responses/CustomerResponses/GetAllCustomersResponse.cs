using net_shop_back.Models;

namespace net_shop_back.Responses.CustomerResponse;

public record GetAllCustomersResponse
{
    public required CustomerModel[] Customers { get; set; }
}