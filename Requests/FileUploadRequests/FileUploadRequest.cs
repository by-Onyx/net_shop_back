using MediatR;
using net_shop_back.Responses.FileUploadResponses;

namespace net_shop_back.Requests.FileUploadRequests;

public record FileUploadRequest : IRequest<FileUploadResponse>
{
    public required IFormFile FormFile { get; set; }
}