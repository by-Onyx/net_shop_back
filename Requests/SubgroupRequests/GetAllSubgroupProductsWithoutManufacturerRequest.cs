using MediatR;
using net_shop_back.Responses.SubgroupResponses;

namespace net_shop_back.Requests.SubgroupRequests;

public record GetAllSubgroupProductsWithoutManufacturerRequest : IRequest<GetAllSubgroupProductsWithoutManufacturerResponse>
{
    public required long SubgroupId { get; set; }
}