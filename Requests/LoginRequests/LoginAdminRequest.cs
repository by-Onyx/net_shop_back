using MediatR;
using net_shop_back.Responses.LoginResponses;

namespace net_shop_back.Requests.LoginRequests;

public record LoginAdminRequest : IRequest<LoginAdminResponse>
{
    public required string Login { get; set; }
    public required string Password { get; set; }
}