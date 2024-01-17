using net_shop_back.Models;

namespace net_shop_back.Responses.ProductResponses;

public class GetFullProductInfoResponse
{
    public required ProductFullInfoModel Product { get; set; }
}