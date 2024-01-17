using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.ProductDescriptionsRequests;
using net_shop_back.Responses.ProductDescriptionsResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/group/subgroup/product/productDescriptions/")] 
[Produces(MediaTypeNames.Application.Json)]
public class ProductDescriptionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductDescriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение всех описаний
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<GetAllProductDescriptionsResponse> GetAllProductDescriptions([FromQuery] GetAllProductDescriptionsRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Получение описания по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{ProductDescriptionId:long}")]
    public Task<GetProductDescriptionResponse> GetProductDescription([FromRoute] GetProductDescriptionRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Обновление описания по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="productDescriptionId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut("{productDescriptionId:long}")]
    public Task<PutProductDescriptionResponse> UpdateProductDescription([FromBody] PutProductDescriptionRequest request, [FromRoute] long productDescriptionId)
    {
        request.Id = productDescriptionId;
        return _mediator.Send(request);
    }

    /// <summary>
    /// Создание описания 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public Task<PostProductDescriptionResponse> CreateProductDescription([FromBody] PostProductDescriptionRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Удаление описания по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{ProductDescriptionId:long}")]
    public Task<DeleteProductDescriptionResponse> DeleteProductDescription([FromRoute] DeleteProductDescriptionRequest request)
        => _mediator.Send(request);
}
