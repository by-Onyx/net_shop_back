namespace net_shop_back.Models;

public record SubgroupModel
{
    public required long Id { get; set; }
    public required long GroupId { get; set; }
    public required string Name { get; set; }
    public required string SubgroupPhotoLink { get; set; }
}

public record SubgroupModelWithCount
{
    public required long Id { get; set; }
    public required long GroupId { get; set; }
    public required string Name { get; set; }
    public required string SubgroupPhotoLink { get; set; }
    public required long ProductCount { get; set; }
}