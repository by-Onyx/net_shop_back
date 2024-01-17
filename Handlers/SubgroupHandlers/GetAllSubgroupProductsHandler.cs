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
    private readonly IMapper _mapper;

    public GetAllSubgroupProductsHandler(IProductService productService, IPhotoService photoService, IMapper mapper)
    {
        _productService = productService;
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<GetAllSubgroupProductsResponse> Handle(GetAllSubgroupProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetAllProductsBySubgroupId(request.SubgroupId);
        var productCards = products.Select(_mapper.Map<ProductCardModel>).ToArray();
        
        foreach (var product in productCards)
        {
            product.Photos = _mapper.Map<PhotoForCardModel[]>(await _photoService.GetAllPhotosByProductIdAsync(product.Id));
        }

        var response = new GetAllSubgroupProductsResponse
        {
            Products = productCards
        };

        return response;
    }
}