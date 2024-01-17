namespace net_shop_back.Entities;

public class Subgroup
{
    public long Id { get; set; }
    public Group? Group { get; set; }
    public required long GroupId { get; set; }
    public required string Name { get; set; }
    public string? SubgroupPhotoLink { get; set; }
}