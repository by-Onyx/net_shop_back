using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.GroupHandlers
{
    public class GetGroupHandler : IRequestHandler<GetGroupRequest, GetGroupResponse>
    {
        private readonly IGroupsService _groupsService;
        private readonly IMapper _mapper;

        public GetGroupHandler(IGroupsService groupsService, IMapper mapper)
        {
            this._groupsService = groupsService;
            this._mapper = mapper;
        }

        public async Task<GetGroupResponse> Handle(GetGroupRequest request, CancellationToken cancellationToken)
        {
            
            var group = await _groupsService.GetGroupByIdAsync(request.GroupId);

            NotFoundException.ThrowIfNull(group);

            var response = new GetGroupResponse
            {
                Group = _mapper.Map<GroupModel>(group)
            };

            return response;
        }
    }
}
