namespace net_shop_back.Models;

public record ManufacturerModel
{
    public long Id { get; set; }
    public required string Name { get; set; }
}