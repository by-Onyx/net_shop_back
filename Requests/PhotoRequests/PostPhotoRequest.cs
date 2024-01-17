using MediatR;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Responses.PhotoResponses;

namespace net_shop_back.Requests.PhotoRequests;

public record PostPhotoRequest : IRequest<PostPhotoResponse>
{
    public required long ProductId { get; set; }
    public required string Link { get; set; }
}