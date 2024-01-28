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
    private readonly IPhotoService _photoService;

    public GetAllProductsHandler(IProductService productService, IPhotoService photoService)
    {
        _productService = productService;
        _photoService = photoService;
    }

    public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsAsync();

        var response = new GetAllProductsResponse
        {
            Products = products
                .Select(x => new ProductModel
                {
                    Id = x.Id,
                    SubgroupId = x.SubgroupId,
                    Name = x.Name,
                    Price = x.Price,
                    ShortDescription = x.ShortDescription,
                    IsAvailable = x.IsAvailable,
                    Count = x.Count,
                    Photos = _photoService.GetAllPhotosByProductIdAsync(x.Id).Result
                        .Select(y => new PhotoForCardModel
                        {
                            Id = y.Id,
                            Link = y.Link
                        }).ToArray()
                })
                .ToArray()
        };

        return response;
    }
}