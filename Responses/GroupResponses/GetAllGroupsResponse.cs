using net_shop_back.Models;

namespace net_shop_back.Responses.GroupResponse
{
    public record GetAllGroupsResponse
    {
        public required GroupModel[] Groups { get; set; }
    }
}
