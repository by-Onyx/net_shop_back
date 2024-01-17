using MediatR;
using net_shop_back.Requests.LoginRequests;
using net_shop_back.Responses.LoginResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.LoginHandlers;

public class LoginAdminHandler : IRequestHandler<LoginAdminRequest, LoginAdminResponse>
{
    private readonly ILoginService _loginService;

    public LoginAdminHandler(ILoginService loginService)
    {
        _loginService = loginService;
    }

    public Task<LoginAdminResponse> Handle(LoginAdminRequest request, CancellationToken cancellationToken)
    {
        var jwt = _loginService.Login(request.Login, request.Password);

        var response = new LoginAdminResponse { Jwt = jwt };

        return Task.FromResult(response);
    }
}