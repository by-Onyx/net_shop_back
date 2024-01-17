using MediatR;
using net_shop_back.Responses.CustomerResponse;

namespace net_shop_back.Requests.CustomerRequest;

public record PostCustomerRequest : IRequest<PostCustomerResponse>
{
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Mail { get; set; }
}