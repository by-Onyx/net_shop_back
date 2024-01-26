using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultFileUploadService : IFileUploadService
{
    private readonly string _uploadPath;

    public DefaultFileUploadService(IWebHostEnvironment hostingEnvironment)
    {
        _uploadPath = Path.Combine("..", "photos");
    }

    public async Task<string> UploadFileAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new IOException("no bytes ;/");
        }
        
        var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + 
                       DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss-ffff") + 
                       Path.GetExtension(file.FileName);
    
        var filePath = Path.Combine(_uploadPath, fileName);

        Directory.CreateDirectory(_uploadPath);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return fileName;
    }

    public async Task<byte[]> GetFile(string fileName)
    {
        var filePath = Path.Combine(_uploadPath, fileName);

        if (File.Exists(filePath))
        {
            return await File.ReadAllBytesAsync(filePath);
        }

        throw new IOException("no bytes ;/");
    }

    public Task DeleteFile(string fileName)
    {
        var filePath = Path.Combine(_uploadPath, fileName);

        if (!File.Exists(filePath)) 
            throw new IOException("no file ;/");
        File.Delete(filePath);
        return Task.CompletedTask;
    }
}