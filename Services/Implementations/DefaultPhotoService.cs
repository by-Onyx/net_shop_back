using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultPhotoService : IPhotoService
{
    private readonly ApplicationContext _ctx;

    public DefaultPhotoService(ApplicationContext ctx)
    {
        _ctx = ctx;
    }

    private DbSet<Photo> Photos => _ctx.Set<Photo>();
    private Task CommitAsync() => _ctx.SaveChangesAsync();

    public async Task<Photo> AddPhotoAsync(long productId, string link)
    {
        var photo = new Photo
        {
            ProductId = productId,
            Link = link
        };

        Photos.Add(photo);
        await CommitAsync();

        return photo;
    }

    public async Task DeletePhotoAsync(long photoId)
    {
        var photo = await GetPhotoByIdAsync(photoId);

        NotFoundException.ThrowIfNull(photo);

        Photos.Remove(photo);
        await CommitAsync();
    }

    public async Task<IReadOnlyCollection<Photo>> GetAllPhotosAsync()
    {
        return await Photos
            .OrderBy(p => p.Id)
            .Select(p => new Photo
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Link = p.Link
            })
            .AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<Photo?> GetPhotoByIdAsync(long photoId)
    {
        return await Photos
            .Where(p => p.Id == photoId)
            .Select(p => new Photo
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Link = p.Link
            })
            .FirstOrDefaultAsync();
    }

    public async Task<Photo?> UpdatePhotoAsync(Photo photo)
    {
        var entity = Photos.Update(photo);
        await CommitAsync();
        return entity.Entity;
    }

    public async Task<IReadOnlyCollection<Photo>> GetAllPhotosByProductIdAsync(long productId)
    {
        return await Photos
            .Where(p => p.ProductId == productId)
            .Select(p => new Photo
            {
                Id = p.Id,
                ProductId = p.ProductId,
                Link = p.Link
            }).AsNoTracking()
            .ToArrayAsync();
    }
}