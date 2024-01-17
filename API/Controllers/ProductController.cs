using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.ProductRequests;
using net_shop_back.Responses.ProductResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/group/subgroup/product/")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение всех продуктов
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<GetAllProductsResponse> GetAllProducts([FromQuery] GetAllProductsRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Получение продукта по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{ProductId:long}")]
    public Task<GetProductResponse> GetProduct([FromRoute] GetProductRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Обновление продукта по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="productId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut("{productId:long}")]
    public Task<PutProductResponse> UpdateProduct([FromBody] PutProductRequest request, [FromRoute] long productId)
    {
        request.Id = productId;
        return _mediator.Send(request);
    }

    /// <summary>
    /// Создание продукта 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public Task<PostProductResponse> CreateProduct([FromBody] PostProductRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Удаление продукта по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{ProductId:long}")]
    public Task<DeleteProductResponse> DeleteProduct([FromRoute] DeleteProductRequest request)
        => _mediator.Send(request);
    
    /// <summary>
    /// Получение полной информации для страници продукта
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{ProductId:long}/fullInfo")]
    public Task<GetFullProductInfoResponse> GetFullProductInfo([FromRoute] GetFullProductInfoRequest request)
        => _mediator.Send(request);
}