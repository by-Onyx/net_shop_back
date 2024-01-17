using MediatR;
using net_shop_back.Responses.SubgroupResponses;

namespace net_shop_back.Requests.SubgroupRequests;

public record PutSubgroupRequest : IRequest<PutSubgroupResponse>
{
    public long Id { get; set; }
    public required long GroupId { get; set; }
    public required string Name { get; set; }
    public string? SubgroupPhotoLink { get; set; }
}