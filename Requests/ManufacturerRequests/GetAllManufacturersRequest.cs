using MediatR;
using net_shop_back.Responses.ManufacturerResponses;

namespace net_shop_back.Requests.ManufacturerRequests;

public record GetAllManufacturersRequest() : IRequest<GetAllManufacturersResponse>;