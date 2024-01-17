using AutoMapper;
using MediatR;
using net_shop_back.Models;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.GroupHandlers;

public class GetAllGroupSubgroupsHandler : IRequestHandler<GetAllGroupSubgroupsRequest, GetAllGroupSubgroupsResponse>
{
    private readonly ISubgroupService _subgroupService;
    private readonly IMapper _mapper;

    public GetAllGroupSubgroupsHandler(IMapper mapper, ISubgroupService subgroupService)
    {
        _mapper = mapper;
        _subgroupService = subgroupService;
    }

    public async Task<GetAllGroupSubgroupsResponse> Handle(GetAllGroupSubgroupsRequest request, CancellationToken cancellationToken)
    {
        var subgroups = await _subgroupService.GetAllSubgroupsByGroupIdAsync(request.GroupId);

        var response = new GetAllGroupSubgroupsResponse
        {
            Subgroups = subgroups
                .Select(_mapper.Map<SubgroupCardModel>)
                .ToArray()
        };

        return response;
    }
}