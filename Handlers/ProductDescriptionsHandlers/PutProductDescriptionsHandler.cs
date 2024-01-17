using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductDescriptionsRequests;
using net_shop_back.Responses.ProductDescriptionsResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductDescriptionsHandlers;

public class PutProductDescriptionHandler : IRequestHandler<PutProductDescriptionRequest, PutProductDescriptionResponse>
{
    private readonly IProductDescriptionService _productDescriptionService;
    private readonly IMapper _mapper;

    public PutProductDescriptionHandler(IProductDescriptionService productDescriptionService, IMapper mapper)
    {
        _productDescriptionService = productDescriptionService;
        _mapper = mapper;
    }

    public async Task<PutProductDescriptionResponse> Handle(PutProductDescriptionRequest request, CancellationToken cancellationToken)
    {
        var productDescription = await _productDescriptionService.UpdateProductDescriptionAsync(new ProductDescription
        {
            Id = request.Id,
            ProductId = request.ProductId,
            Header = request.Header,
            Text = request.Text
        });

        NotFoundException.ThrowIfNull(productDescription);

        var response = new PutProductDescriptionResponse
        {
            ProductDescription = _mapper.Map<ProductDescriptionModel>(productDescription)
        };

        return response;
    }
}