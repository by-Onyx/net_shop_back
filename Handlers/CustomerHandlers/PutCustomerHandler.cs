using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.CustomerRequest;
using net_shop_back.Responses.CustomerResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.CustomerHandlers;

public class PutCustomerHandler : IRequestHandler<PutCustomerRequest, PutCustomerResponse>
{
    private readonly ICustomersService _customersService;
    private readonly IMapper _mapper;

    public PutCustomerHandler(ICustomersService customersService, IMapper mapper)
    {
        _customersService = customersService;
        _mapper = mapper;
    }

    public async Task<PutCustomerResponse> Handle(PutCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _customersService.UpdateCustomerAsync(new Customer
        {
            Id = request.Id,
            Name = request.Name,
            PhoneNumber = request.PhoneNumber,
            Mail = request.Mail
        });

        NotFoundException.ThrowIfNull(customer);

        var response = new PutCustomerResponse
        {
            Customer = _mapper.Map<CustomerModel>(customer)
        };

        return response;
    }
}