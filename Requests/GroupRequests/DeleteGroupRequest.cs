using MediatR;
using net_shop_back.Responses.GroupResponse;

namespace net_shop_back.Requests.GroupRequest
{
    public record DeleteGroupRequest : IRequest<DeleteGroupResponse>
    {
        public required long GroupId { get; set; }
    }
}
