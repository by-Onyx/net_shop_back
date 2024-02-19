using MediatR;
using net_shop_back.Responses.MailResponses;

namespace net_shop_back.Requests.MailRequests;

public record SendMailAboutCallRequest : IRequest<SendMailAboutCallResponse>
{
    public required string PhoneNumber { get; set; }
}