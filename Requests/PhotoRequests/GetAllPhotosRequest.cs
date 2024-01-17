using MediatR;
using net_shop_back.Responses.PhotoResponses;

namespace net_shop_back.Requests.PhotoRequests;

public record GetAllPhotosRequest : IRequest<GetAllPhotosResponse> { }