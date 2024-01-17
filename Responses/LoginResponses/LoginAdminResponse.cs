using System.IdentityModel.Tokens.Jwt;

namespace net_shop_back.Responses.LoginResponses;

public record LoginAdminResponse
{
    public required string Jwt { get; set; }
}