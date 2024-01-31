using net_shop_back.Entities;

namespace net_shop_back.Services.Core;

public interface IManufacturerService
{
    public Task<Manufacturer> AddManufacturerAsync(string name);
    public Task DeleteManufacturerAsync(long id);
    public Task<Manufacturer?> GetManufacturerByIdAsync(long id);
    public Task<IReadOnlyCollection<Manufacturer>> GetAllManufacturersAsync();
    public Task<Manufacturer> UpdateManufacturerNameAsync(Manufacturer manufacturer);
}