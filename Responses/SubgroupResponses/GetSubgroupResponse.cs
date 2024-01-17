using net_shop_back.Models;

namespace net_shop_back.Responses.SubgroupResponses;

public record GetSubgroupResponse
{
    public required SubgroupModel Subgroup { get; set; }
}