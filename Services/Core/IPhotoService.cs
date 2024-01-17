using net_shop_back.Entities;

namespace net_shop_back.Services.Core;

public interface IPhotoService
{
    public Task<Photo> AddPhotoAsync(long productId, string link);
    public Task DeletePhotoAsync(long photoId);
    public Task<IReadOnlyCollection<Photo>> GetAllPhotosAsync();
    public Task<Photo?> GetPhotoByIdAsync(long photoId);
    public Task<Photo?> UpdatePhotoAsync(Photo photo);
    public Task<IReadOnlyCollection<Photo>> GetAllPhotosByProductIdAsync(long productId);
}