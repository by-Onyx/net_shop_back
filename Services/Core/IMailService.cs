using net_shop_back.Models;

namespace net_shop_back.Services.Core;

public interface IMailService
{
    public Task SendMailAboutPurchaseAsync(string name, string phoneNumber, ProductMailModel[] products);
}