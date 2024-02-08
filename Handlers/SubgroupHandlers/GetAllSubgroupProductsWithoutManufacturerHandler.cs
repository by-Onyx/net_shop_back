using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class GetAllSubgroupProductsWithoutManufacturerHandler 
    : IRequestHandler<GetAllSubgroupProductsWithoutManufacturerRequest, GetAllSubgroupProductsWithoutManufacturerResponse>
{
    private readonly IProductService _productService;
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public GetAllSubgroupProductsWithoutManufacturerHandler(IProductService productService, IPhotoService photoService, IMapper mapper)
    {
        _productService = productService;
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<GetAllSubgroupProductsWithoutManufacturerResponse> Handle(GetAllSubgroupProductsWithoutManufacturerRequest request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsBySubgroupId(request.SubgroupId);
        var productCards = products.Select(_mapper.Map<ProductCardModel>).ToArray();
        
        foreach (var product in productCards)
        {
            product.Photos = _mapper.Map<PhotoForCardModel[]>(await _photoService.GetAllPhotosByProductIdAsync(product.Id));
        }

        var response = new GetAllSubgroupProductsWithoutManufacturerResponse
        {
            Products = productCards
        };

        return response;
    }
}