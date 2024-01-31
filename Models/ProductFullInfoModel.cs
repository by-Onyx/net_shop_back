namespace net_shop_back.Models;

public class ProductFullInfoModel
{
    public required long Id { get; set; }
    public required long SubgroupId { get; set; }
    public required long GroupId { get; set; }
    public required long ManufacturerId { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public required int Priority { get; set; }
    public required string ShortDescription { get; set; }
    public required bool IsAvailable { get; set; } 
    public required int Count { get; set; }
    public required IReadOnlyCollection<PhotoForCardModel> Photos { get; set; }
    public required IReadOnlyCollection<DescriptionForCardModel> ProductDescriptions { get; set; }
}