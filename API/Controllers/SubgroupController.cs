using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/group/subgroup/")]
[Produces(MediaTypeNames.Application.Json)]
public class SubgroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubgroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение всех подгрупп
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<GetAllSubgroupsResponse> GetAllSubgroups([FromQuery] GetAllSubgroupsRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Получение подгруппы по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{SubgroupId:long}")]
    public Task<GetSubgroupResponse> GetSubgroup([FromRoute] GetSubgroupRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Обновление подгруппы по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="subgroupId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut("{subgroupId:long}")]
    public Task<PutSubgroupResponse> UpdateSubgroup([FromBody] PutSubgroupRequest request, [FromRoute] long subgroupId)
    {
        request.Id = subgroupId;
        return _mediator.Send(request);
    }

    /// <summary>
    /// Создание подгруппы 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public Task<PostSubgroupResponse> CreateSubgroup([FromBody] PostSubgroupRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Удаление подгруппы по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{SubgroupId:long}")]
    public Task<DeleteSubgroupResponse> DeleteSubgroup([FromRoute] DeleteSubgroupRequest request)
        => _mediator.Send(request);
    
    /// <summary>
    /// Получение всех товаров в подгруппе по Id подгруппы
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{SubgroupId:long}/products")]
    public Task<GetAllSubgroupProductsResponse> GetAllSubgroupProducts([FromRoute] GetAllSubgroupProductsRequest request)
        => _mediator.Send(request);
}