using net_shop_back.Models;

namespace net_shop_back.Responses.PhotoResponses;

public record GetAllPhotosResponse
{
    public required PhotoModel[] Photos { get; set; }
}