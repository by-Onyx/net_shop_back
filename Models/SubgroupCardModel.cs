namespace net_shop_back.Models;

public record SubgroupCardModel
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string SubgroupPhotoLink { get; set; }
    public required long ProductCount { get; set; }
}