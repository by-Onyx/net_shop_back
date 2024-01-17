using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.GroupHandlers
{
    public class PostGroupHandler : IRequestHandler<PostGroupRequest, PostGroupResponse>
    {
        private readonly IGroupsService _groupsService;
        private readonly IMapper _mapper;

        public PostGroupHandler(IGroupsService groupsService, IMapper mapper)
        {
            this._groupsService = groupsService;
            _mapper = mapper;
        }

        public async Task<PostGroupResponse> Handle(PostGroupRequest request, CancellationToken cancellationToken)
        {
            var group = await _groupsService.AddGroupAsync(request.Name, request.GroupPhotoLink);

            var response = new PostGroupResponse
            {
                Group = _mapper.Map<GroupModel>(group)
            };
            
            return response;
        }
    }
}
