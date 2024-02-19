using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.MailRequests;
using net_shop_back.Responses.MailResponses;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/mail/")]
[Produces(MediaTypeNames.Application.Json)]
public class MailController : ControllerBase
{
    private readonly IMediator _mediator;

    public MailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Отправка сообщения о заказе пользователя по почте
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("purchase")]
    public Task<SendMailAboutPurchaseResponse> SendPurchaseMail([FromBody] SendMailAboutPurchaseRequest request)
        => _mediator.Send(request);
    
    /// <summary>
    /// Отправка сообщения о звонке пользователю
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("call")]
    public Task<SendMailAboutCallResponse> SendCallMail([FromBody] SendMailAboutCallRequest request)
        => _mediator.Send(request);
}