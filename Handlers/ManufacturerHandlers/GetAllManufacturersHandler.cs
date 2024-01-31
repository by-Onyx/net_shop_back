using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.ManufacturerRequests;
using net_shop_back.Responses.ManufacturerResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ManufacturerHandlers;

public class GetAllManufacturersHandler : IRequestHandler<GetAllManufacturersRequest, GetAllManufacturersResponse>
{
    private readonly IManufacturerService _manufacturerService;

    public GetAllManufacturersHandler(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    public async Task<GetAllManufacturersResponse> Handle(GetAllManufacturersRequest request, CancellationToken cancellationToken)
    {
        var manufacturers = await _manufacturerService.GetAllManufacturersAsync();

        return new GetAllManufacturersResponse
        {
            Manufacturers = manufacturers
                .Select(p => new ManufacturerModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToArray()
        };
    }
}