using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.ManufacturerRequests;
using net_shop_back.Responses.ManufacturerResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ManufacturerHandlers;

public class PostManufacturerHandler : IRequestHandler<PostManufacturerRequest, PostManufacturerResponse>
{
    private readonly IManufacturerService _manufacturerService;

    public PostManufacturerHandler(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    public async Task<PostManufacturerResponse> Handle(PostManufacturerRequest request, CancellationToken cancellationToken)
    {
        var manufacturer = await _manufacturerService.AddManufacturerAsync(request.Name);

        return new PostManufacturerResponse
        {
            Manufacturer = new ManufacturerModel
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name
            }
        };
    }
}