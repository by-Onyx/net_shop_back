using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class PostProductHandler : IRequestHandler<PostProductRequest, PostProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public PostProductHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<PostProductResponse> Handle(PostProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.AddProductAsync(
            request.SubgroupId, 
            request.Name,
            request.Price,
            request.IsAvailable,
            request.Count,
            request.ShortDescription);

        var response = new PostProductResponse
        {
            Product = _mapper.Map<ProductModel>(product)
        };

        return response;
    }
}