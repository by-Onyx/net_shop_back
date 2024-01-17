namespace net_shop_back.Models;

public record PhotoModel
{
    public required long Id { get; set; }
    public required long ProductId { get; set; }
    public required string Link { get; set; }
}