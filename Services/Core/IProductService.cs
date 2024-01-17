using net_shop_back.Entities;
using net_shop_back.Models;

namespace net_shop_back.Services.Core;

public interface IProductService
{
    public Task<Product> AddProductAsync(long subgroupId, string name, 
        decimal price, bool? isAvailable, int? count, string shortDescription);
    public Task DeleteProductAsync(long id);
    public Task<IReadOnlyCollection<Product>> GetAllProductsAsync();
    public Task<Product?> GetProductByIdAsync(long id);
    public Task<Product?> UpdateProductAsync(Product product);
    public Task<IReadOnlyCollection<Product>> GetAllProductsBySubgroupId(long subgroupId);
}