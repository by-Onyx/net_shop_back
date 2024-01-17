using MediatR;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.PhotoHandlers;

public class DeletePhotoHandler : IRequestHandler<DeletePhotoRequest, DeletePhotoResponse>
{
    private readonly IPhotoService _photoService;

    public DeletePhotoHandler(IPhotoService photoService)
    {
        _photoService = photoService;
    }

    public async Task<DeletePhotoResponse> Handle(DeletePhotoRequest request, CancellationToken cancellationToken)
    {
        await _photoService.DeletePhotoAsync(request.PhotoId);

        var response = new DeletePhotoResponse();

        return response;
    }
}