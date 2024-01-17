namespace net_shop_back.Entities
{
    public record Product
    {
        public long Id { get; set; }
        public Subgroup? Subgroup { get; set; }
        public required long SubgroupId { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public string? ShortDescription { get; set; }
        public bool? IsAvailable { get; set; } = false;
        public int? Count { get; set; } = 0;
    }
}
