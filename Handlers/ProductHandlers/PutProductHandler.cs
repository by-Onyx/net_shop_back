using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.ProductHandlers;

public class PutProductHandler : IRequestHandler<PutProductRequest, PutProductResponse>
{
    private readonly IProductService _productService;
    private readonly IProductDescriptionService _productDescriptionService;
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public PutProductHandler(IProductService productService, 
        IMapper mapper, 
        IProductDescriptionService productDescriptionService, 
        IPhotoService photoService)
    {
        _productService = productService;
        _mapper = mapper;
        _productDescriptionService = productDescriptionService;
        _photoService = photoService;
    }

    public async Task<PutProductResponse> Handle(PutProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productService.UpdateProductAsync(new Product
        {
            Id = request.Id,
            SubgroupId = request.SubgroupId,
            Name = request.Name,
            Price = decimal.Round(request.Price,2),
            ShortDescription = request.ShortDescription,
            IsAvailable = request.IsAvailable,
            Count = request.Count
        });
        
        NotFoundException.ThrowIfNull(product);

        for (int i = 0; i < request.Photos.Count; i++)
        {
            if (request.Photos[i].Id < 0)
            {
                var photo = await _photoService.AddPhotoAsync(request.Id, request.Photos[i].Link);
                request.Photos[i] = new PhotoForCardModel
                {
                    Id = photo.Id,
                    Link = photo.Link
                };
            }
        }
        
        for (int i = 0; i < request.ProductDescriptions.Count; i++)
        {
            if (request.ProductDescriptions[i].Id < 0)
            {
                var productDescription = await _productDescriptionService.AddProductDescriptionAsync(
                    request.Id,
                    request.ProductDescriptions[i].Header,
                    request.ProductDescriptions[i].Text);
                request.ProductDescriptions[i] = new DescriptionForCardModel
                {
                    Id = productDescription.Id,
                    Header = productDescription.Header,
                    Text = productDescription.Text
                };
            }
        }
        
        var response = new PutProductResponse
        {
            Product = new ProductFullInfoModelSub
            {
                Id = product.Id,
                SubgroupId = product.SubgroupId,
                Name = product.Name,
                Price = product.Price,
                ShortDescription = product.ShortDescription!,
                IsAvailable = product.IsAvailable!.Value,
                Count = product.Count!.Value,
                Photos = request.Photos,
                ProductDescriptions = request.ProductDescriptions
            }
        };

        return response;
    }
}