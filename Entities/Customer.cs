namespace net_shop_back.Entities
{
    public record Customer
    {
        public long Id { get; set; }    
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Mail { get; set; }
    }
}
