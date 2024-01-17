using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class GetSubgroupHandler : IRequestHandler<GetSubgroupRequest, GetSubgroupResponse>
{
    private readonly ISubgroupService _subgroupService;
    private readonly IMapper _mapper;

    public GetSubgroupHandler(ISubgroupService subgroupService, IMapper mapper)
    {
        _subgroupService = subgroupService;
        _mapper = mapper;
    }

    public async Task<GetSubgroupResponse> Handle(GetSubgroupRequest request, CancellationToken cancellationToken)
    {
        var subgroup = await _subgroupService.GetSubgroupByIdAsync(request.SubgroupId);

        NotFoundException.ThrowIfNull(subgroup);

        var response = new GetSubgroupResponse
        {
            Subgroup = _mapper.Map<SubgroupModel>(subgroup)
        };

        return response;
    }
}