using MediatR;
using net_shop_back.Responses.PhotoResponses;

namespace net_shop_back.Requests.PhotoRequests;

public record DeletePhotoRequest : IRequest<DeletePhotoResponse>
{
    public required long PhotoId { get; set; }
}