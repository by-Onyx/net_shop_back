using MediatR;
using net_shop_back.Responses.GroupResponse;

namespace net_shop_back.Requests.GroupRequest
{
    public record PostGroupRequest : IRequest<PostGroupResponse>
    {
        public required string Name { get; set; }
        public string? GroupPhotoLink { get; set; }
    }
}
