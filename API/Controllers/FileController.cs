using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_shop_back.Requests.FileUploadRequests;
using net_shop_back.Responses.FileUploadResponses;
using net_shop_back.Services.Core;

namespace net_shop_back.API.Controllers;

[ApiController]
[Route("/constrspb/file/")]
[Produces(MediaTypeNames.Application.Json)]
public class FileController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFileUploadService _fileUploadService;

    public FileController(IMediator mediator, IFileUploadService fileUploadService)
    {
        _mediator = mediator;
        _fileUploadService = fileUploadService;
    }
    
    /// <summary>
    /// Загружаем файл на сервер
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<FileUploadResponse> UploadFile([FromForm] FileUploadRequest request)
        => _mediator.Send(request);
    
    /// <summary>
    /// Получение файла по id
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet("get/{fileName}")]
    public async Task<IActionResult> GetFile(string fileName)
    {
        try
        {
            var fileBytes = await _fileUploadService.GetFile(fileName);

            var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
            string contentType;

            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                default:
                    contentType = "application/octet-stream";
                    break;
            }

            return File(fileBytes, contentType);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Удаление файла
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("delete/{fileName}")]
    public async Task<IActionResult> DeleteFile(string fileName)
    {
        try
        {
            await _fileUploadService.DeleteFile(fileName);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
        
    }
}