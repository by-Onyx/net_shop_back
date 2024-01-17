using net_shop_back.Entities;
using net_shop_back.Models;

namespace net_shop_back.Services.Core;

public interface ISubgroupService
{
    public Task<Subgroup> AddSubgroupAsync(long groupId, string name, string? photo);
    public Task DeleteSubgroupAsync(long id);
    public Task<IReadOnlyCollection<Subgroup>> GetAllSubgroupsAsync();
    public Task<Subgroup?> GetSubgroupByIdAsync(long id);
    public Task<Subgroup?> UpdateSubgroupAsync(Subgroup subgroup);
    public Task<IReadOnlyCollection<Subgroup>> GetAllSubgroupsByGroupIdAsync(long groupId);

}