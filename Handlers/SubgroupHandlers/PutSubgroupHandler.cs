using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class PutSubgroupHandler : IRequestHandler<PutSubgroupRequest, PutSubgroupResponse>
{
    private readonly ISubgroupService _subgroupService;
    private readonly IMapper _mapper;

    public PutSubgroupHandler(ISubgroupService subgroupService, IMapper mapper)
    {
        _subgroupService = subgroupService;
        _mapper = mapper;
    }

    public async Task<PutSubgroupResponse> Handle(PutSubgroupRequest request, CancellationToken cancellationToken)
    {
        var subgroup = await _subgroupService.UpdateSubgroupAsync(new Subgroup
        {
            Id = request.Id,
            GroupId = request.GroupId,
            Name = request.Name,
            SubgroupPhotoLink = request.SubgroupPhotoLink
        });

        NotFoundException.ThrowIfNull(subgroup);

        var response = new PutSubgroupResponse
        {
            Subgroup = _mapper.Map<SubgroupModel>(subgroup)
        };

        return response;
    }
}