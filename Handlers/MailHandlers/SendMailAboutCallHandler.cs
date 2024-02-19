using MediatR;
using net_shop_back.Requests.MailRequests;
using net_shop_back.Responses.MailResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.Handlers.MailHandlers;

public class SendMailAboutCallHandler : IRequestHandler<SendMailAboutCallRequest, SendMailAboutCallResponse>
{
    private readonly IMailService _mailService;

    public SendMailAboutCallHandler(IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task<SendMailAboutCallResponse> Handle(SendMailAboutCallRequest request, CancellationToken cancellationToken)
    {
        await _mailService.SendMailAboutCallAsync(request.PhoneNumber);
        
        return new SendMailAboutCallResponse();
    }
}