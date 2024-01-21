namespace net_shop_back.Models;

public class ProductFullInfoModelSub
{
    public required long Id { get; set; }
    public required long SubgroupId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required string ShortDescription { get; set; }
    public required bool IsAvailable { get; set; } 
    public required int Count { get; set; }
    public required List<PhotoForCardModel> Photos { get; set; }
    public required List<DescriptionForCardModel> ProductDescriptions { get; set; }
}