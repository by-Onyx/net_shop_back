using MediatR;
using net_shop_back.Responses.CustomerResponse;

namespace net_shop_back.Requests.CustomerRequest;

public record DeleteCustomerRequest : IRequest<DeleteCustomerResponse>
{
    public required long CustomerId { get; set; }
}