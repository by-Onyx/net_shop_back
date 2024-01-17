using net_shop_back.Models;

namespace net_shop_back.Responses.SubgroupResponses;

public record PutSubgroupResponse
{
    public required SubgroupModel Subgroup { get; set; }
}