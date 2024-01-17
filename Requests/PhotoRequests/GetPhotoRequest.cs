using MediatR;
using net_shop_back.Responses.PhotoResponses;

namespace net_shop_back.Requests.PhotoRequests;

public record GetPhotoRequest : IRequest<GetPhotoResponse>
{
    public required long PhotoId { get; set; }
}