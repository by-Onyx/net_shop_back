using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductDescriptionsHandlers;

public class GetFullProductInfoHandler : IRequestHandler<GetFullProductInfoRequest, GetFullProductInfoResponse>
{
    private readonly IProductService _productService;
    private readonly IPhotoService _photoService;
    private readonly IProductDescriptionService _descriptionService;
    private readonly IMapper _mapper;

    public GetFullProductInfoHandler(IProductService productService, IPhotoService photoService, IProductDescriptionService descriptionService, IMapper mapper)
    {
        _productService = productService;
        _photoService = photoService;
        _descriptionService = descriptionService;
        _mapper = mapper;
    }

    public async Task<GetFullProductInfoResponse> Handle(GetFullProductInfoRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.GetProductByIdAsync(request.ProductId);
        
        NotFoundException.ThrowIfNull(product);
        
        var photos = await _photoService.GetAllPhotosByProductIdAsync(request.ProductId);
        var descriptions = await _descriptionService.GetAllProductDescriptionsByProductIdAsync(request.ProductId);

        var response = new GetFullProductInfoResponse
        {
            Product = new ProductFullInfoModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ShortDescription = product.ShortDescription!,
                IsAvailable = product.IsAvailable!.Value,
                Count = product.Count!.Value,
                Photos = _mapper.Map<PhotoForCardModel[]>(photos),
                ProductDescriptions = _mapper.Map<DescriptionForCardModel[]>(descriptions)
            }
        };

        return response;
    }
}