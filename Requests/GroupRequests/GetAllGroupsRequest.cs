using MediatR;
using net_shop_back.Responses.GroupResponse;

namespace net_shop_back.Requests.GroupRequest
{
    public record GetAllGroupsRequest : IRequest<GetAllGroupsResponse> { }
}
