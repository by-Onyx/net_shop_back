namespace net_shop_back.Entities
{
    public record ProductDescription
    {
        public long Id { get; set; }
        public Product? Product { get; set; }
        public required long ProductId { get; set; }
        public required string Header { get; set; }
        public required string Text { get; set; }
    }
}
