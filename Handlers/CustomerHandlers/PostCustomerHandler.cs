using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.CustomerRequest;
using net_shop_back.Responses.CustomerResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.CustomerHandlers;


public class PostCustomerHandler : IRequestHandler<PostCustomerRequest, PostCustomerResponse>
{
    private readonly ICustomersService _customersService;
    private readonly IMapper _mapper;

    public PostCustomerHandler(ICustomersService customersService, IMapper mapper)
    {
        _customersService = customersService;
        _mapper = mapper;
    }

    public async Task<PostCustomerResponse> Handle(PostCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customersService.AddCustomerAsync(request.Name, request.PhoneNumber, request.Mail);

        var response = new PostCustomerResponse
        {
            Customer = _mapper.Map<CustomerModel>(customer)
        };

        return response;
    }
}