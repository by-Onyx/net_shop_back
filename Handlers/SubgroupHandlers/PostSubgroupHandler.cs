using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Models;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class PostSubgroupHandler : IRequestHandler<PostSubgroupRequest, PostSubgroupResponse>
{
    private readonly ISubgroupService _subgroupService;
    private readonly IMapper _mapper;

    public PostSubgroupHandler(ISubgroupService subgroupService, IMapper mapper)
    {
        _subgroupService = subgroupService;
        _mapper = mapper;
    }

    public async Task<PostSubgroupResponse> Handle(PostSubgroupRequest request, CancellationToken cancellationToken)
    {
        var subgroup = await _subgroupService.AddSubgroupAsync(request.GroupId, request.Name, request.GroupPhotoLink);

        var response = new PostSubgroupResponse
        {
            Subgroup = _mapper.Map<SubgroupModel>(subgroup)
        };

        return response;
    }
}