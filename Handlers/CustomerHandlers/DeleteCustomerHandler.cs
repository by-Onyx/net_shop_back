using MediatR;
using net_shop_back.Requests.CustomerRequest;
using net_shop_back.Responses.CustomerResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.CustomerHandlers;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
{
    private readonly ICustomersService _customersService;

    public DeleteCustomerHandler(ICustomersService customersService)
    {
        _customersService = customersService;
    }

    public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        await _customersService.DeleteCustomerAsync(request.CustomerId);

        var response = new DeleteCustomerResponse();

        return response;
    }
}