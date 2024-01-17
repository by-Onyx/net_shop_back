using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.LoginRequests;
using net_shop_back.Responses.LoginResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/admin/login")]
[Produces(MediaTypeNames.Application.Json)]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получение JWT-токена через логин и пароль
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet]
    public Task<LoginAdminResponse> LoginAdmin([FromQuery] LoginAdminRequest request)
        => _mediator.Send(request);
}