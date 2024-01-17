using MediatR;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IProductService _productService;

    public DeleteProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        await _productService.DeleteProductAsync(request.ProductId);

        var response = new DeleteProductResponse();

        return response;
    }
}