using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductDescriptionsRequests;
using net_shop_back.Responses.ProductDescriptionsResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductDescriptionsHandlers;

public class GetProductDescriptionHandler : IRequestHandler<GetProductDescriptionRequest, GetProductDescriptionResponse>
{
    private readonly IProductDescriptionService _productDescriptionService;
    private readonly IMapper _mapper;

    public GetProductDescriptionHandler(IProductDescriptionService productDescriptionService, IMapper mapper)
    {
        _productDescriptionService = productDescriptionService;
        _mapper = mapper;
    }

    public async Task<GetProductDescriptionResponse> Handle(GetProductDescriptionRequest request, CancellationToken cancellationToken)
    {
        var productDescription = await _productDescriptionService.GetProductDescriptionByIdAsync(request.ProductDescriptionId);

        NotFoundException.ThrowIfNull(productDescription);

        var response = new GetProductDescriptionResponse
        {
            ProductDescription = _mapper.Map<ProductDescriptionModel>(productDescription)
        };

        return response;
    }
}