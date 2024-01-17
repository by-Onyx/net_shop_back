using net_shop_back.Entities;

namespace net_shop_back.Services.Core;

public interface IProductDescriptionService
{
    public Task<ProductDescription> AddProductDescriptionAsync(long productId, string header, string text);
    public Task DeleteProductDescriptionAsync(long productDescriptionId);
    public Task<IReadOnlyCollection<ProductDescription>> GetAllProductDescriptionsAsync();
    public Task<ProductDescription?> GetProductDescriptionByIdAsync(long productDescriptionId);
    public Task<ProductDescription?> UpdateProductDescriptionAsync(ProductDescription productDescription);
    public Task<IReadOnlyCollection<ProductDescription>> GetAllProductDescriptionsByProductIdAsync(long productId);
}