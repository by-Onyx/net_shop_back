using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultCustomersService : ICustomersService
{
    private readonly ApplicationContext _ctx;

    public DefaultCustomersService(ApplicationContext ctx)
    {
        _ctx = ctx;
    }
    
    private DbSet<Customer> Customers => _ctx.Set<Customer>();
    private Task CommitAsync() => _ctx.SaveChangesAsync();
    
    public async Task<Customer> AddCustomerAsync(string name, string phoneNumber, string? mail)
    {
        var customer = new Customer
        {
            Name = name,
            PhoneNumber = phoneNumber,
            Mail = mail
        };
        Customers.Add(customer);
        await CommitAsync();

        return customer;
    }

    public async Task DeleteCustomerAsync(long id)
    {
        var customer = await GetCustomerByIdAsync(id);

        NotFoundException.ThrowIfNull(customer);

        Customers.Remove(customer);
        await CommitAsync();
    }

    public async Task<IReadOnlyCollection<Customer>> GetAllCustomersAsync()
    {
        return await Customers
            .OrderBy(c => c.Id)
            .Select(c => new Customer
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Mail = c.Mail
            }).AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(long id)
    {
        return await Customers
            .Where(c => c.Id == id)
            .Select(c => new Customer
            {
                Id = c.Id,
                Name = c.Name,
                PhoneNumber = c.PhoneNumber,
                Mail = c.Mail
            }).FirstOrDefaultAsync();
    }

    public async Task<Customer?> UpdateCustomerAsync(Customer customer)
    {
        var entity = Customers.Update(customer);
        await CommitAsync();
        return entity.Entity;
    }
}