using MediatR;
using net_shop_back.Requests.SubgroupRequests;
using net_shop_back.Responses.SubgroupResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.SubgroupHandlers;

public class DeleteSubgroupHandler : IRequestHandler<DeleteSubgroupRequest, DeleteSubgroupResponse>
{
    private readonly ISubgroupService _subgroupService;

    public DeleteSubgroupHandler(ISubgroupService subgroupService)
    {
        _subgroupService = subgroupService;
    }

    public async Task<DeleteSubgroupResponse> Handle(DeleteSubgroupRequest request, CancellationToken cancellationToken)
    {
        await _subgroupService.DeleteSubgroupAsync(request.SubgroupId);

        var response = new DeleteSubgroupResponse();

        return response;
    }
}