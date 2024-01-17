using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.ProductDescriptionsRequests;
using net_shop_back.Responses.ProductDescriptionsResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductDescriptionsHandlers;

public class PostProductDescriptionHandler : IRequestHandler<PostProductDescriptionRequest, PostProductDescriptionResponse>
{
    private readonly IProductDescriptionService _productDescriptionService;
    private readonly IMapper _mapper;

    public PostProductDescriptionHandler(IProductDescriptionService productDescriptionService, IMapper mapper)
    {
        _productDescriptionService = productDescriptionService;
        _mapper = mapper;
    }

    public async Task<PostProductDescriptionResponse> Handle(PostProductDescriptionRequest request, CancellationToken cancellationToken)
    {
        var productDescription = await _productDescriptionService.AddProductDescriptionAsync(request.ProductId, request.Header, request.Text);

        var response = new PostProductDescriptionResponse
        {
            ProductDescription = _mapper.Map<ProductDescriptionModel>(productDescription)
        };

        return response;
    }
}