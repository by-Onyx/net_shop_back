using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public GetAllProductsHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsAsync();

        var response = new GetAllProductsResponse
        {
            Products = products
                .Select(_mapper.Map<ProductModel>)
                .ToArray()
        };

        return response;
    }
}