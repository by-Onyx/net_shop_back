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
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public GetProductHandler(IProductService productService, IMapper mapper, IPhotoService photoService)
    {
        _productService = productService;
        _mapper = mapper;
        _photoService = photoService;
    }

    public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductByIdAsync(request.ProductId);
        
        NotFoundException.ThrowIfNull(product);

        var photos = await _photoService.GetAllPhotosByProductIdAsync(request.ProductId);

        var response = new GetProductResponse
        {
            Product = new ProductModelWithPhoto
            {
                Id = product.Id,
                SubgroupId = product.SubgroupId,
                Name = product.Name,
                Price = product.Price,
                ShortDescription = product.ShortDescription!,
                IsAvailable = product.IsAvailable!.Value,
                Count = product.Count!.Value,
                Photos = _mapper.Map<PhotoForCardModel[]>(photos),
            }
        };

        return response;
    }
}