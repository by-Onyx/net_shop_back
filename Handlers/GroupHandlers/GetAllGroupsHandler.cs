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
        private readonly IMapper _mapper;

        public GetAllGroupsHandler(IGroupsService groupsService, IMapper mapper)
        {
            this._groupsService = groupsService;
            this._mapper = mapper;
        }

        public async Task<GetAllGroupsResponse> Handle(GetAllGroupsRequest request, CancellationToken cancellationToken)
        {
            var groups = await _groupsService.GetAllGroupsAsync();

            var response = new GetAllGroupsResponse
            {
                Groups = groups
                    .Select(_mapper.Map<GroupModel>)
                    .ToArray()
            };

            return response;
        }
    }
}
