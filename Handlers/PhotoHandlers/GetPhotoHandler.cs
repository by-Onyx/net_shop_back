using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.PhotoHandlers;

public class GetPhotoHandler : IRequestHandler<GetPhotoRequest, GetPhotoResponse>
{
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public GetPhotoHandler(IPhotoService photoService, IMapper mapper)
    {
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<GetPhotoResponse> Handle(GetPhotoRequest request, CancellationToken cancellationToken)
    {
        var photo = await _photoService.GetPhotoByIdAsync(request.PhotoId);

        NotFoundException.ThrowIfNull(photo);

        var response = new GetPhotoResponse
        {
            Photo = _mapper.Map<PhotoModel>(photo)
        };

        return response;
    }
}