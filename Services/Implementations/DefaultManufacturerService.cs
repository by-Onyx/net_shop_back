using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultManufacturerService : IManufacturerService
{
    private readonly ApplicationContext _ctx;

    public DefaultManufacturerService(ApplicationContext ctx)
    {
        _ctx = ctx;
    }
  
    private DbSet<Manufacturer> Manufacturers => _ctx.Set<Manufacturer>();
    private Task CommitAsync() => _ctx.SaveChangesAsync();

    public async Task<Manufacturer> AddManufacturerAsync(string name)
    {
        var manufacturer = new Manufacturer
        {
            Name = name
        };
        Manufacturers.Add(manufacturer);
        await CommitAsync();

        return manufacturer;
    }

    public async Task DeleteManufacturerAsync(long id)
    {
        var manufacturer = await GetManufacturerByIdAsync(id);
        
        NotFoundException.ThrowIfNull(manufacturer);

        Manufacturers.Remove(manufacturer);
        await CommitAsync();
    }

    public async Task<IReadOnlyCollection<Manufacturer>> GetAllManufacturersAsync()
    {
        return await Manufacturers
            .OrderBy(m => m.Id)
            .Select(p => new Manufacturer
            {
                Id = p.Id,
                Name = p.Name
            }).AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<Manufacturer?> GetManufacturerByIdAsync(long id)
    {
        return await Manufacturers
            .Where(m => m.Id == id)
            .Select(p => new Manufacturer
            {
                Id = p.Id,
                Name = p.Name
            }).FirstOrDefaultAsync();
    }

    public async Task<Manufacturer> UpdateManufacturerNameAsync(Manufacturer manufacturer)
    {
        var entity = Manufacturers.Update(manufacturer);
        await CommitAsync();
        return entity.Entity;
    }
}