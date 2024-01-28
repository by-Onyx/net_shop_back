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
    private readonly IProductService _productService;

    public GetAllSubgroupsHandler(ISubgroupService subgroupService, IProductService productService)
    {
        _subgroupService = subgroupService;
        _productService = productService;
    }

    public async Task<GetAllSubgroupsResponse> Handle(GetAllSubgroupsRequest request, CancellationToken cancellationToken)
    {
        var subgroups = await _subgroupService.GetAllSubgroupsAsync();

        var response = new GetAllSubgroupsResponse
        {
            Subgroups = subgroups
                .Select(x => new SubgroupModelWithCount
                {
                    Id =x.Id,
                    GroupId = x.GroupId,
                    Name = x.Name,
                    SubgroupPhotoLink = x.SubgroupPhotoLink,
                    ProductCount = _productService.GetAllProductsBySubgroupId(x.Id).Result.Count
                }).ToArray()
        };

        return response;
    }
}