using System.IdentityModel.Tokens.Jwt;

namespace net_shop_back.Services.Core;

public interface ILoginService
{   
    public string Login(string login, string password);
}