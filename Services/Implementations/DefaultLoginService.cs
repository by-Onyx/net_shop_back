using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using dotenv.net;
using Microsoft.IdentityModel.Tokens;
using net_shop_back.Exceptions;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultLoginService : ILoginService
{
    private readonly IConfiguration _config;

    public DefaultLoginService(IConfiguration config)
    {
        _config = config;
    }

    public string Login(string login, string password)
    {
        DotEnv.Load();
        
        if (login != _config["Admin:Login"] ||
            password != _config["Admin:Password"])
        {
            ForbiddenException.ThrowIfDeny("Invalid username or password.");
        }
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"] ?? string.Empty));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> {new Claim(ClaimTypes.Name, login) };

        var token = new JwtSecurityToken(
            /*issuer: _config["JWT:ValidIssuer"],
            audience: _config["JWT:ValidAudience"],*/
            claims: claims,
            expires: DateTime.Now.AddHours(3),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GetToken()
    {
        return new JwtSecurityToken(
            issuer: _config["JWT:ValidIssuer"],
            audience: _config["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            signingCredentials: 
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"] 
                                                                    ?? throw new InvalidOperationException())),
                    SecurityAlgorithms.HmacSha256)
        );
    }
}