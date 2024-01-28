using MediatR;
using net_shop_back.Requests.MailRequests;
using net_shop_back.Responses.MailResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.MailHandlers;

public class SendMailAboutPurchaseHandler : IRequestHandler<SendMailAboutPurchaseRequest, SendMailAboutPurchaseResponse>
{
    private readonly IMailService _mailService;

    public SendMailAboutPurchaseHandler(IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task<SendMailAboutPurchaseResponse> Handle(SendMailAboutPurchaseRequest request, CancellationToken cancellationToken)
    {
        await _mailService.SendMailAboutPurchaseAsync(request.Name, request.PhoneNumber, request.Products);

        var response = new SendMailAboutPurchaseResponse();

        return response;
    }
}