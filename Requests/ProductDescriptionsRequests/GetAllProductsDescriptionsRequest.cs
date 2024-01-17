﻿using MediatR;
using net_shop_back.Responses.ProductDescriptionsResponses;

namespace net_shop_back.Requests.ProductDescriptionsRequests;

public record GetAllProductDescriptionsRequest : IRequest<GetAllProductDescriptionsResponse> { }