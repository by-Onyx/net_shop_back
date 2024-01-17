using MediatR;
using net_shop_back.Responses.CustomerResponse;

namespace net_shop_back.Requests.CustomerRequest;

public record GetAllCustomersRequest : IRequest<GetAllCustomersResponse> { }