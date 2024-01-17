using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.CustomerRequest;
using net_shop_back.Responses.CustomerResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.CustomerHandlers;

public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersRequest, GetAllCustomersResponse>
{
    private readonly ICustomersService _customersService;
    private readonly IMapper _mapper;

    public GetAllCustomersHandler(ICustomersService customersService, IMapper mapper)
    {
        _customersService = customersService;
        _mapper = mapper;
    }

    public async Task<GetAllCustomersResponse> Handle(GetAllCustomersRequest request, CancellationToken cancellationToken)
    {
        var customers = await _customersService.GetAllCustomersAsync();

        var response = new GetAllCustomersResponse
        {
            Customers = customers
                .Select(_mapper.Map<CustomerModel>)
                .ToArray()
        };

        return response;
    }
}