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
    private readonly IProductService _productService;

    public GetAllGroupSubgroupsHandler(ISubgroupService subgroupService, IProductService productService)
    {
        _subgroupService = subgroupService;
        _productService = productService;
    }

    public async Task<GetAllGroupSubgroupsResponse> Handle(GetAllGroupSubgroupsRequest request, CancellationToken cancellationToken)
    {
        var subgroups = await _subgroupService.GetAllSubgroupsByGroupIdAsync(request.GroupId);

        var response = new GetAllGroupSubgroupsResponse
        {
            Subgroups = subgroups
                .Select(x => new SubgroupCardModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    SubgroupPhotoLink = x.SubgroupPhotoLink,
                    ProductCount = _productService.GetAllProductsBySubgroupId(x.Id).Result.Count
                })
                .ToArray()
        };

        return response;
    }
}