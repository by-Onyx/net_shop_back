namespace net_shop_back.Models;

public record CustomerModel
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Mail { get; set; }
}