using MediatR;
using net_shop_back.Requests.ProductDescriptionsRequests;
using net_shop_back.Responses.ProductDescriptionsResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductDescriptionsHandlers;

public class DeleteProductDescriptionHandler : IRequestHandler<DeleteProductDescriptionRequest, DeleteProductDescriptionResponse>
{
    private readonly IProductDescriptionService _productDescriptionService;

    public DeleteProductDescriptionHandler(IProductDescriptionService productDescriptionService)
    {
        _productDescriptionService = productDescriptionService;
    }

    public async Task<DeleteProductDescriptionResponse> Handle(DeleteProductDescriptionRequest request, CancellationToken cancellationToken)
    {
        await _productDescriptionService.DeleteProductDescriptionAsync(request.ProductDescriptionId);

        var response = new DeleteProductDescriptionResponse();

        return response;
    }
}