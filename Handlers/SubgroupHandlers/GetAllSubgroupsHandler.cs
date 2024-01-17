using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class GetAllSubgroupsHandler : IRequestHandler<GetAllSubgroupsRequest, GetAllSubgroupsResponse>
{
    private readonly ISubgroupService _subgroupService;
    private readonly IMapper _mapper;

    public GetAllSubgroupsHandler(ISubgroupService subgroupService, IMapper mapper)
    {
        _subgroupService = subgroupService;
        _mapper = mapper;
    }

    public async Task<GetAllSubgroupsResponse> Handle(GetAllSubgroupsRequest request, CancellationToken cancellationToken)
    {
        var subgroups = await _subgroupService.GetAllSubgroupsAsync();

        var response = new GetAllSubgroupsResponse
        {
            Subgroups = subgroups
                .Select(_mapper.Map<SubgroupModel>)
                .ToArray()
        };

        return response;
    }
}