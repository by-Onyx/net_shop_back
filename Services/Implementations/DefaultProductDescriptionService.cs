using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultProductDescriptionService : IProductDescriptionService
{
    private readonly ApplicationContext _ctx;

    public DefaultProductDescriptionService(ApplicationContext ctx)
    {
        _ctx = ctx;
    }

    private DbSet<ProductDescription> ProductDescriptions => _ctx.Set<ProductDescription>();

    private Task CommitAsync() => _ctx.SaveChangesAsync();

    public async Task<ProductDescription> AddProductDescriptionAsync(long productId, string header, string text)
    {
        var productDescription = new ProductDescription
        {
            ProductId = productId,
            Header = header,
            Text = text
        };

        ProductDescriptions.Add(productDescription);
        await CommitAsync();

        return productDescription;
    }

    public async Task DeleteProductDescriptionAsync(long productDescriptionId)
    {
        var productDescription = await GetProductDescriptionByIdAsync(productDescriptionId);

        NotFoundException.ThrowIfNull(productDescription);

        ProductDescriptions.Remove(productDescription);
        await CommitAsync();
    }

    public async Task<IReadOnlyCollection<ProductDescription>> GetAllProductDescriptionsAsync()
    {
        return await ProductDescriptions
            .OrderBy(pd => pd.Id)
            .Select(pd => new ProductDescription
            {
                Id = pd.Id,
                ProductId = pd.ProductId,
                Header = pd.Header,
                Text = pd.Text
            })
            .AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<ProductDescription?> GetProductDescriptionByIdAsync(long productDescriptionId)
    {
        return await ProductDescriptions
            .Where(pd => pd.Id == productDescriptionId)
            .Select(pd => new ProductDescription
            {
                Id = pd.Id,
                ProductId = pd.ProductId,
                Header = pd.Header,
                Text = pd.Text
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ProductDescription?> UpdateProductDescriptionAsync(ProductDescription productDescription)
    {
        var entity = ProductDescriptions.Update(productDescription);
        await CommitAsync();
        return entity.Entity;
    }

    public async Task<IReadOnlyCollection<ProductDescription>> GetAllProductDescriptionsByProductIdAsync(long productId)
    {
        return await ProductDescriptions
            .Where(pd => pd.ProductId == productId)
            .Select(pd => new ProductDescription
            {
                Id = pd.Id,
                ProductId = pd.ProductId,
                Header = pd.Header,
                Text = pd.Text
            })
            .AsNoTracking()
            .ToArrayAsync();
    }
}
