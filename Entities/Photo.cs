namespace net_shop_back.Entities
{
    public record Photo
    {
        public long Id { get; set; }
        public Product? Product { get; set; }
        public required long ProductId { get; set; }
        public required string Link { get; set; }
    }
}
