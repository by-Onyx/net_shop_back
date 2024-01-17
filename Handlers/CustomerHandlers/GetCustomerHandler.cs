using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.CustomerRequest;
using net_shop_back.Responses.CustomerResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.CustomerHandlers;

public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    private readonly ICustomersService _customersService;
    private readonly IMapper _mapper;

    public GetCustomerHandler(ICustomersService customersService, IMapper mapper)
    {
        _customersService = customersService;
        _mapper = mapper;
    }

    public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customersService.GetCustomerByIdAsync(request.CustomerId);

        NotFoundException.ThrowIfNull(customer);

        var response = new GetCustomerResponse
        {
            Customer = _mapper.Map<CustomerModel>(customer)
        };

        return response;
    }
}
