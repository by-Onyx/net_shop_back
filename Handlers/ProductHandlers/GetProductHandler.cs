using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public GetProductHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductByIdAsync(request.ProductId);

        NotFoundException.ThrowIfNull(product);

        var response = new GetProductResponse
        {
            Product = _mapper.Map<ProductModel>(product)
        };

        return response;
    }
}