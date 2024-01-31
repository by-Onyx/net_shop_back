using MediatR;
using net_shop_back.Responses.ManufacturerResponses;

namespace net_shop_back.Requests.ManufacturerRequests;

public class DeleteManufacturerRequest : IRequest<DeleteManufacturerResponse>
{
    public required long ManufacturerId { get; set; }
}