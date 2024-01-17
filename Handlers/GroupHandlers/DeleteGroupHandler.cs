using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.GroupHandlers
{
    public class DeleteWarehouseHandler : IRequestHandler<DeleteGroupRequest, DeleteGroupResponse>
    {
        private readonly IGroupsService _groupsService;

        public DeleteWarehouseHandler(IGroupsService groupsService)
        {
            this._groupsService = groupsService;
        }

        public async Task<DeleteGroupResponse> Handle(DeleteGroupRequest request, CancellationToken cancellationToken)
        {
            await _groupsService.DeleteGroupAsync(request.GroupId);

            var response = new DeleteGroupResponse();

            return response;
        }
    }
}
