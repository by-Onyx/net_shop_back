using net_shop_back.Models;

namespace net_shop_back.Responses.SubgroupResponses;

public record GetAllSubgroupsResponse
{
    public required SubgroupModelWithCount[] Subgroups { get; set; }
}