using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.ProductDescriptionsRequests;
using net_shop_back.Responses.ProductDescriptionsResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductDescriptionsHandlers;

public class GetAllProductDescriptionsHandler : IRequestHandler<GetAllProductDescriptionsRequest, GetAllProductDescriptionsResponse>
{
    private readonly IProductDescriptionService _productDescriptionService;
    private readonly IMapper _mapper;

    public GetAllProductDescriptionsHandler(IProductDescriptionService productDescriptionService, IMapper mapper)
    {
        _productDescriptionService = productDescriptionService;
        _mapper = mapper;
    }

    public async Task<GetAllProductDescriptionsResponse> Handle(GetAllProductDescriptionsRequest request, CancellationToken cancellationToken)
    {
        var productDescriptions = await _productDescriptionService.GetAllProductDescriptionsAsync();

        var response = new GetAllProductDescriptionsResponse
        {
            ProductDescriptions = productDescriptions
                .Select(_mapper.Map<ProductDescriptionModel>)
                .ToArray()
        };

        return response;
    }
}