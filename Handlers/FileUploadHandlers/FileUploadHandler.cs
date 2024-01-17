using MediatR;
using net_shop_back.Requests.FileUploadRequests;
using net_shop_back.Responses.FileUploadResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.FileUploadHandlers;

public class FileUploadHandler : IRequestHandler<FileUploadRequest, FileUploadResponse>
{
    private readonly IFileUploadService _fileUploadService;

    public FileUploadHandler(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService;
    }

    public async Task<FileUploadResponse> Handle(FileUploadRequest request, CancellationToken cancellationToken)
    {
        var fileName = await _fileUploadService.UploadFileAsync(request.FormFile);

        return new FileUploadResponse { FileName = fileName };
    }
}