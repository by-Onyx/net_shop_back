using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class ChangeProductPriorityHandler : IRequestHandler<ChangeProductPriorityRequest, ChangeProductPriorityResponse>
{
    private readonly IProductService _productService;
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public ChangeProductPriorityHandler(IProductService productService, IPhotoService photoService, IMapper mapper)
    {
        _productService = productService;
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<ChangeProductPriorityResponse> Handle(ChangeProductPriorityRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.ChangeProductPriority(request.ProductId, request.Priority);
        
        NotFoundException.ThrowIfNull(product);

        var photos = await _photoService.GetAllPhotosByProductIdAsync(request.ProductId);

        return new ChangeProductPriorityResponse
        {
            Product = new ProductModelWithPhoto
            {
                Id = product.Id,
                SubgroupId = product.SubgroupId,
                ManufacturerId = product.ManufacturerId,
                Name = product.Name,
                Price = product.Price,
                Priority = product.Priority,
                ShortDescription = product.ShortDescription!,
                IsAvailable = product.IsAvailable!.Value,
                Count = product.Count!.Value,
                Photos = _mapper.Map<PhotoForCardModel[]>(photos),
            }
        };
    }
}