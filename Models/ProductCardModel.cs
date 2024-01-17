using net_shop_back.Entities;

namespace net_shop_back.Models;

public record ProductCardModel
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required bool IsAvailable { get; set; } = false;
    public required IReadOnlyCollection<PhotoForCardModel> Photos { get; set; }
}