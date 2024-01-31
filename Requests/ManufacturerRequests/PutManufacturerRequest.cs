using MediatR;
using net_shop_back.Responses.ManufacturerResponses;

namespace net_shop_back.Requests.ManufacturerRequests;

public record PutManufacturerRequest : IRequest<PutManufacturerResponse>
{
    public long Id { get; set; }
    public required string Name { get; set; }
}