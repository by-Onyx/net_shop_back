namespace net_shop_back.Models;

public record ProductMailModel
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Count { get; set; }
}