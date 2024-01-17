using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.PhotoHandlers;

public class GetAllPhotosHandler : IRequestHandler<GetAllPhotosRequest, GetAllPhotosResponse>
{
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public GetAllPhotosHandler(IPhotoService photoService, IMapper mapper)
    {
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<GetAllPhotosResponse> Handle(GetAllPhotosRequest request, CancellationToken cancellationToken)
    {
        var photos = await _photoService.GetAllPhotosAsync();

        var response = new GetAllPhotosResponse
        {
            Photos = photos
                .Select(_mapper.Map<PhotoModel>)
                .ToArray()
        };

        return response;
    }
}