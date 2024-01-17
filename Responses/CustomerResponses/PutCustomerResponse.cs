using net_shop_back.Models;

namespace net_shop_back.Responses.CustomerResponse;

public record PutCustomerResponse
{
    public required CustomerModel Customer { get; set; }
}