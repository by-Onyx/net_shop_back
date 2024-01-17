namespace net_shop_back.Responses.FileUploadResponses;

public record FileUploadResponse
{
    public required string FileName { get; set; }
}