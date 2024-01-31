using MediatR;
using net_shop_back.Requests.ManufacturerRequests;
using net_shop_back.Responses.ManufacturerResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ManufacturerHandlers;

public class DeleteManufacturerHandler : IRequestHandler<DeleteManufacturerRequest, DeleteManufacturerResponse>
{
    private readonly IManufacturerService _manufacturerService;

    public DeleteManufacturerHandler(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    public async Task<DeleteManufacturerResponse> Handle(DeleteManufacturerRequest request, CancellationToken cancellationToken)
    {
        await _manufacturerService.DeleteManufacturerAsync(request.ManufacturerId);

        return new DeleteManufacturerResponse();
    }
}