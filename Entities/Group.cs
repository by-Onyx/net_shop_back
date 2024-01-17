namespace net_shop_back.Entities
{
    public record Group
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? GroupPhotoLink { get; set; }
    }
}
