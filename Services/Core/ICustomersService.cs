using net_shop_back.Entities;

namespace net_shop_back.Services.Core;

public interface ICustomersService
{
    public Task<Customer> AddCustomerAsync(string name, string phoneNumber, string? mail);
    public Task DeleteCustomerAsync(long id);
    public Task<IReadOnlyCollection<Customer>> GetAllCustomersAsync();
    public Task<Customer?> GetCustomerByIdAsync(long id);
    public Task<Customer?> UpdateCustomerAsync(Customer customer);
}