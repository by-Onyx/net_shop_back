using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/group/subgroup/product/photo/")] 
[Produces(MediaTypeNames.Application.Json)]
public class PhotoController : ControllerBase
{
    private readonly IMediator _mediator;

    public PhotoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение всех фото 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<GetAllPhotosResponse> GetAllPhotos([FromQuery] GetAllPhotosRequest request)
        => _mediator.Send(request);
    
    /// <summary>
    /// Получение фото по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{PhotoId:long}")]
    public Task<GetPhotoResponse> GetPhoto([FromRoute] GetPhotoRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Обновление фото по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="photoId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut("{photoId:long}")]
    public Task<PutPhotoResponse> UpdatePhoto([FromBody] PutPhotoRequest request, [FromRoute] long photoId)
    {
        request.Id = photoId;
        return _mediator.Send(request);
    }

    /// <summary>
    /// Создание фото 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public Task<PostPhotoResponse> CreatePhoto([FromBody] PostPhotoRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Удаление фото по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{PhotoId:long}")]
    public Task<DeletePhotoResponse> DeletePhoto([FromRoute] DeletePhotoRequest request)
        => _mediator.Send(request);
}