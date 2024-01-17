using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultProductsService : IProductService
{
    private readonly ApplicationContext _ctx;
    private readonly IPhotoService _photoService;

    public DefaultProductsService(ApplicationContext ctx, IPhotoService photoService)
    {
        _ctx = ctx;
        _photoService = photoService;
    }

    private DbSet<Product> Products => _ctx.Set<Product>();
    private Task CommitAsync() => _ctx.SaveChangesAsync();

    public async Task<Product> AddProductAsync(long subgroupId, string name, 
        decimal price, bool? isAvailable, int? count, string shortDescription)
    {
        var product = new Product
        {
            SubgroupId = subgroupId,
            Name = name,
            Price = decimal.Round(price,2),
            IsAvailable = isAvailable,
            Count = count,
            ShortDescription = shortDescription
        };
        Products.Add(product);
        await CommitAsync();

        return product;
    }

    public async Task DeleteProductAsync(long id)
    {
        var product = await GetProductByIdAsync(id);

        NotFoundException.ThrowIfNull(product);

        Products.Remove(product);
        await CommitAsync();
    }

    public async Task<IReadOnlyCollection<Product>> GetAllProductsAsync()
    {
        return await Products
            .OrderBy(p => p.Id)
            .Select(p => new Product
            {
                Id = p.Id,
                SubgroupId = p.SubgroupId,
                Name = p.Name,
                Price = p.Price,
                ShortDescription = p.ShortDescription,
                IsAvailable = p.IsAvailable,
                Count = p.Count
            }).AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<Product?> GetProductByIdAsync(long id)
    {
        return await Products
            .Where(p => p.Id == id)
            .Select(p => new Product
            {
                Id = p.Id,
                SubgroupId = p.SubgroupId,
                Name = p.Name,
                Price = p.Price,
                ShortDescription = p.ShortDescription,
                IsAvailable = p.IsAvailable,
                Count = p.Count
            }).FirstOrDefaultAsync();
    }

    public async Task<Product?> UpdateProductAsync(Product product)
    {
        var entity = Products.Update(product);
        await CommitAsync();
        return entity.Entity;
    }

    public async Task<IReadOnlyCollection<Product>> GetAllProductsBySubgroupId(long subgroupId)
    {
        return await Products
            .Where(p => p.SubgroupId == subgroupId)
            .Select(p => new Product
            {
                Id = p.Id,
                SubgroupId = p.SubgroupId,
                Name = p.Name,
                Price = p.Price,
                ShortDescription = p.ShortDescription,
                IsAvailable = p.IsAvailable,
                Count = p.Count
            }).AsNoTracking()
            .ToArrayAsync();
    }
}