namespace net_shop_back.Models;

public record ProductDescriptionModel
{
    public long Id { get; set; }
    public required long ProductId { get; set; }
    public required string Header { get; set; }
    public required string Text { get; set; }
}