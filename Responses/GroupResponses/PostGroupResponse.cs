using net_shop_back.Models;

namespace net_shop_back.Responses.GroupResponse
{
    public record PostGroupResponse
    {
        public required GroupModel Group { get; set; }
    }
}
