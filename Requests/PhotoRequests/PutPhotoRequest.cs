using MediatR;
using net_shop_back.Responses.PhotoResponses;

namespace net_shop_back.Requests.PhotoRequests;

public record PutPhotoRequest : IRequest<PutPhotoResponse>
{
    public long Id { get; set; }
    public required long ProductId { get; set; }
    public required string Link { get; set; }
}