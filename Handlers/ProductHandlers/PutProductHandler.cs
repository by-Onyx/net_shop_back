using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class PutProductHandler : IRequestHandler<PutProductRequest, PutProductResponse>
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public PutProductHandler(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<PutProductResponse> Handle(PutProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.UpdateProductAsync(new Product
        {
            Id = request.Id,
            SubgroupId = request.SubgroupId,
            Name = request.Name,
            Price = decimal.Round(request.Price,2),
            ShortDescription = request.ShortDescription,
            IsAvailable = request.IsAvailable,
            Count = request.Count
        });

        NotFoundException.ThrowIfNull(product);

        var response = new PutProductResponse
        {
            Product = _mapper.Map<ProductModel>(product)
        };

        return response;
    }
}