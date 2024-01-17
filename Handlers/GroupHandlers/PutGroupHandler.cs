using AutoMapper;
using MediatR;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.GroupHandlers
{
    public class PutGroupHandler : IRequestHandler<PutGroupRequest, PutGroupResponse>
    {
        private readonly IGroupsService _groupsService;
        private readonly IMapper _mapper;

        public PutGroupHandler(IGroupsService groupsService, IMapper mapper)
        {
            this._groupsService = groupsService;
            this._mapper = mapper;
        }

        public async Task<PutGroupResponse> Handle(PutGroupRequest request, CancellationToken cancellationToken)
        {
            var group = await _groupsService.UpdateGroupNameAsync(new Group 
            { 
                Id = request.Id, 
                Name = request.Name,
                GroupPhotoLink = request.GroupPhotoLink
            });

            NotFoundException.ThrowIfNull(group);

            var response = new PutGroupResponse 
            { 
                Group = _mapper.Map<GroupModel>(group) 
            };

            return response;
        }
    }
}
