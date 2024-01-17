using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.CustomerRequest;
using net_shop_back.Responses.CustomerResponse;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/customer/")]
[Produces(MediaTypeNames.Application.Json)]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet]
    public Task<GetAllCustomersResponse> GetAllCustomers([FromQuery] GetAllCustomersRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Получение пользователя по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet("{CustomerId:long}")]
    public Task<GetCustomerResponse> GetCustomer([FromRoute] GetCustomerRequest request)
        => _mediator.Send(request);

    /// <summary>
    /// Обновление информации о пользователе по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut("{customerId:long}")]
    public Task<PutCustomerResponse> UpdateCustomer([FromBody] PutCustomerRequest request, [FromRoute] long customerId)
    {
        request.Id = customerId;
        return _mediator.Send(request);
    }
    
    /// <summary>
    /// Создать пользователя 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public Task<PostCustomerResponse> CreateCustomer([FromBody] PostCustomerRequest request)
        => _mediator.Send(request);
    
    /// <summary>
    /// Удалить пользователя по его Id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("{CustomerId:long}")]
    public Task<DeleteCustomerResponse> DeleteCustomer([FromRoute] DeleteCustomerRequest request)
        => _mediator.Send(request);
}
