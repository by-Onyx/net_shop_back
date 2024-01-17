using MediatR;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.GroupRequest;
using net_shop_back.Responses.GroupResponse;
using System.Net.Mime;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace net_shop_back.API.Controllers
{
    [ApiController]
    [Route("/constrspb/group/")]
    [Produces(MediaTypeNames.Application.Json)]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получение всех групп 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<GetAllGroupsResponse> GetAllGroups([FromQuery] GetAllGroupsRequest request)
            => _mediator.Send(request);

        /// <summary>
        /// Получение группы по его Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{GroupId:long}")]
        public Task<GetGroupResponse> GetGroup([FromRoute] GetGroupRequest request)
            => _mediator.Send(request);

        /// <summary>
        /// Обновление группы по его Id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{groupId:long}")]
        public Task<PutGroupResponse> UpdateGroupName([FromBody] PutGroupRequest request, [FromRoute] long groupId)
        {
            request.Id = groupId;
            return _mediator.Send(request);
        }

        /// <summary>
        /// Создание группы 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public Task<PostGroupResponse> CreateGroup([FromBody] PostGroupRequest request)
            => _mediator.Send(request); 
        
        /// <summary>
        /// Удаление группы по его Id
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{GroupId:long}")]
        public Task<DeleteGroupResponse> DeleteGroup([FromRoute] DeleteGroupRequest request)
            => _mediator.Send(request);

        /// <summary>
        /// Получение всех подгрупп в группе по Id группы
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("{GroupId:long}/subgroups")]
        public Task<GetAllGroupSubgroupsResponse> GetAllGroupSubgroups([FromRoute] GetAllGroupSubgroupsRequest request)
            => _mediator.Send(request);
    }
}
