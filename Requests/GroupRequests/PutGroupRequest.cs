using MediatR;
using net_shop_back.Responses.GroupResponse;

namespace net_shop_back.Requests.GroupRequest
{
    public record PutGroupRequest : IRequest<PutGroupResponse>
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? GroupPhotoLink { get; set; }
    }
}
