using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ManufacturerRequests;
using net_shop_back.Responses.ManufacturerResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ManufacturerHandlers;

public class PutManufacturerHandler : IRequestHandler<PutManufacturerRequest, PutManufacturerResponse>
{
    private readonly IManufacturerService _manufacturerService;

    public PutManufacturerHandler(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    public async Task<PutManufacturerResponse> Handle(PutManufacturerRequest request, CancellationToken cancellationToken)
    {
        var manufacturer = await _manufacturerService.UpdateManufacturerNameAsync(new Manufacturer
        {
            Id = request.Id,
            Name = request.Name
        });
        
        NotFoundException.ThrowIfNull(manufacturer);

        return new PutManufacturerResponse
        {
            Manufacturer = new ManufacturerModel
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            }
        };
    }
}