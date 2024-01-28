using MediatR;
using net_shop_back.Models;
using net_shop_back.Responses.MailResponses;

namespace net_shop_back.Requests.MailRequests;

public record SendMailAboutPurchaseRequest : IRequest<SendMailAboutPurchaseResponse>
{
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required ProductMailModel[] Products { get; set; }
}