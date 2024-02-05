using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class GetAllSubgroupProductsHandler : IRequestHandler<GetAllSubgroupProductsRequest, GetAllSubgroupProductsResponse>
{
    private readonly IProductService _productService;
    private readonly IPhotoService _photoService;
    private readonly IManufacturerService _manufacturerService;
    private readonly IMapper _mapper;

    public GetAllSubgroupProductsHandler(IProductService productService, IPhotoService photoService, IMapper mapper, IManufacturerService manufacturerService)
    {
        _productService = productService;
        _photoService = photoService;
        _mapper = mapper;
        _manufacturerService = manufacturerService;
    }

    public async Task<GetAllSubgroupProductsResponse> Handle(GetAllSubgroupProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsBySubgroupId(request.SubgroupId);
        var productCards = products.Select(_mapper.Map<ProductCardModel>).GroupBy(x => x.ManufacturerId).ToList();

        List<ManufacturerGroupModel> models = new List<ManufacturerGroupModel>(); 
        
        foreach (var product in productCards.SelectMany(x => x))
        {
            product.Photos = _mapper.Map<PhotoForCardModel[]>(await _photoService.GetAllPhotosByProductIdAsync(product.Id));
        }

        foreach (var productCard in productCards)
        {
            models.Add(new ManufacturerGroupModel
            {
                Manufacturer = await _manufacturerService.GetManufacturerByIdAsync(productCard.Key),
                Products = productCards.Where(x => x.Key == productCard.Key).SelectMany(x => x).ToArray()
            });
        }
        
        var response = new GetAllSubgroupProductsResponse
        {
            ManufacturerGroupModels = models.ToArray()
        };

        return response;
    }
}