using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.PhotoHandlers;

public class PutPhotoHandler : IRequestHandler<PutPhotoRequest, PutPhotoResponse>
{
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public PutPhotoHandler(IPhotoService photoService, IMapper mapper)
    {
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<PutPhotoResponse> Handle(PutPhotoRequest request, CancellationToken cancellationToken)
    {
        var photo = await _photoService.UpdatePhotoAsync(new Photo
        {
            Id = request.Id,
            ProductId = request.ProductId,
            Link = request.Link
        });

        NotFoundException.ThrowIfNull(photo);

        var response = new PutPhotoResponse
        {
            Photo = _mapper.Map<PhotoModel>(photo)
        };

        return response;
    }
}