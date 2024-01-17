namespace net_shop_back.Services.Core;

public interface IFileUploadService
{
    public Task<string> UploadFileAsync(IFormFile file);
    public Task<byte[]> GetFile(string fileName);
    public Task DeleteFile(string fileName);
}