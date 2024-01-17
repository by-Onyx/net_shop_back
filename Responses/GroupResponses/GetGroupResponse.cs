using net_shop_back.Entities;
using net_shop_back.Models;

namespace net_shop_back.Responses.GroupResponse
{
    public record GetGroupResponse
    {
        public required GroupModel Group { get; set; }
    }
}
