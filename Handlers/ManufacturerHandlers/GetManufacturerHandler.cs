using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ManufacturerRequests;
using net_shop_back.Responses.ManufacturerResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ManufacturerHandlers;

public class GetManufacturerHandler : IRequestHandler<GetManufacturerRequest, GetManufacturerResponse>
{
    private readonly IManufacturerService _manufacturerService;

    public GetManufacturerHandler(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    public async Task<GetManufacturerResponse> Handle(GetManufacturerRequest request, CancellationToken cancellationToken)
    {
        var manufacturer = await _manufacturerService.GetManufacturerByIdAsync(request.ManufacturerId);
        
        NotFoundException.ThrowIfNull(manufacturer);

        return new GetManufacturerResponse
        {
            Manufacturer = new ManufacturerModel
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            }
        };
    }
}