namespace net_shop_back.Models
{
    public record GroupModel
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public string? GroupPhotoLink { get; set; }
    }
}
