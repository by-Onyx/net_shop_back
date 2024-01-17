using MediatR;
using net_shop_back.Responses.SubgroupResponses;

namespace net_shop_back.Requests.SubgroupRequests;

public class GetAllSubgroupProductsRequest : IRequest<GetAllSubgroupProductsResponse>
{
    public required long SubgroupId { get; set; }
}