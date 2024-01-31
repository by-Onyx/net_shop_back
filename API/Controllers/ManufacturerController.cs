using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.ManufacturerRequests;
using net_shop_back.Responses.ManufacturerResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/manufacturer/")]
[Produces(MediaTypeNames.Application.Json)]
public class ManufacturerController
{
    private readonly IMediator _mediator;

    public ManufacturerController(IMediator mediator)
    {
        _mediator = mediator;
    }
  
    [HttpGet]
    public Task<GetAllManufacturersResponse> GetAllManufacturers([FromQuery] GetAllManufacturersRequest request)
        => _mediator.Send(request);

    [HttpGet("{ManufacturerId:long}")]
    public Task<GetManufacturerResponse> GetManufacturer([FromRoute] GetManufacturerRequest request)
        => _mediator.Send(request);

    [Authorize]
    [HttpPut("{manufacturerId:long}")]
    public Task<PutManufacturerResponse> UpdateManufacturerName([FromBody] PutManufacturerRequest request, [FromRoute] long manufacturerId)
    {
        request.Id = manufacturerId;
        return _mediator.Send(request);
    }

    [Authorize]
    [HttpPost]
    public Task<PostManufacturerResponse> CreateManufacturer([FromBody] PostManufacturerRequest request)
        => _mediator.Send(request);

    [Authorize]
    [HttpDelete("{ManufacturerId:long}")]
    public Task<DeleteManufacturerResponse> DeleteManufacturer([FromRoute] DeleteManufacturerRequest request)
        => _mediator.Send(request);
}