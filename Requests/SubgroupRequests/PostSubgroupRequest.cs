using MediatR;
using net_shop_back.Responses.SubgroupResponses;

namespace net_shop_back.Requests.SubgroupRequests;

public record PostSubgroupRequest : IRequest<PostSubgroupResponse>
{
    public required long GroupId { get; set; }
    public required string Name { get; set; }
    public string? GroupPhotoLink { get; set; }
}
