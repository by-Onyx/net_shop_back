using System.Diagnostics;
using MediatR;
using net_shop_back.Requests.PhotoRequests;
using net_shop_back.Responses.PhotoResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.PhotoHandlers;

public class DeletePhotoHandler : IRequestHandler<DeletePhotoRequest, DeletePhotoResponse>
{
    private readonly IPhotoService _photoService;
    private readonly IFileUploadService _fileUploadService;

    public DeletePhotoHandler(IPhotoService photoService, IFileUploadService fileUploadService)
    {
        _photoService = photoService;
        _fileUploadService = fileUploadService;
    }

    public async Task<DeletePhotoResponse> Handle(DeletePhotoRequest request, CancellationToken cancellationToken)
    {
        var photo = await _photoService.GetPhotoByIdAsync(request.PhotoId);
        await _photoService.DeletePhotoAsync(request.PhotoId);

        Debug.Assert(photo != null, nameof(photo) + " != null");
        await _fileUploadService.DeleteFile(photo.Link);
        
        var response = new DeletePhotoResponse();

        return response;
    }
}