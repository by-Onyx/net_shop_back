using AutoMapper;
using MediatR;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.GroupHandlers
{
    public class GetAllGroupsHandler : IRequestHandler<GetAllGroupsRequest, GetAllGroupsResponse>
    {
        private readonly IGroupsService _groupsService;
        private readonly ISubgroupService _subgroupService;

        public GetAllGroupsHandler(IGroupsService groupsService, ISubgroupService subgroupService)
        {
            this._groupsService = groupsService;
            _subgroupService = subgroupService;
        }

        public async Task<GetAllGroupsResponse> Handle(GetAllGroupsRequest request, CancellationToken cancellationToken)
        {
            var groups = await _groupsService.GetAllGroupsAsync();

            var response = new GetAllGroupsResponse
            {
                Groups = groups
                    .Select(x => new GroupModelWithCount
                    {
                        Id = x.Id,
                        Name = x.Name,
                        GroupPhotoLink = x.GroupPhotoLink,
                        SubgroupCount =  _subgroupService.GetAllSubgroupsByGroupIdAsync(x.Id).Result.Count
                    }).ToArray()
            };

            return response;
        }
    }
}
