using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.PhotoHandlers;

public class PostPhotoHandler : IRequestHandler<PostPhotoRequest, PostPhotoResponse>
{
    private readonly IPhotoService _photoService;
    private readonly IMapper _mapper;

    public PostPhotoHandler(IPhotoService photoService, IMapper mapper)
    {
        _photoService = photoService;
        _mapper = mapper;
    }

    public async Task<PostPhotoResponse> Handle(PostPhotoRequest request, CancellationToken cancellationToken)
    {
        var photo = await _photoService.AddPhotoAsync(request.ProductId, request.Link);

        var response = new PostPhotoResponse
        {
            Photo = _mapper.Map<PhotoModel>(photo)
        };

        return response;
    }
}