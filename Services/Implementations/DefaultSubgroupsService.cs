using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations;

[DefaultService]
public class DefaultSubgroupsService : ISubgroupService
{
    private readonly ApplicationContext _ctx;

    public DefaultSubgroupsService(ApplicationContext ctx)
    {
        _ctx = ctx;
    }
    
    private DbSet<Subgroup> Subgroups => _ctx.Set<Subgroup>();
    private Task CommitAsync() => _ctx.SaveChangesAsync();

    public async Task<Subgroup> AddSubgroupAsync(long groupId, string name, string? photo)
    {
        var subgroup = new Subgroup
        {
            GroupId = groupId,
            Name = name,
            SubgroupPhotoLink = photo
        };
        Subgroups.Add(subgroup);
        await CommitAsync();

        return subgroup;
    }

    public async Task DeleteSubgroupAsync(long id)
    {
        var subgroup = await GetSubgroupByIdAsync(id);

        NotFoundException.ThrowIfNull(subgroup);

        Subgroups.Remove(subgroup);
        await CommitAsync();
    }

    public async Task<IReadOnlyCollection<Subgroup>> GetAllSubgroupsAsync()
    {
        return await Subgroups
            .OrderBy(p => p.Id)
            .Select(p => new Subgroup
            {
                Id = p.Id,
                GroupId = p.GroupId,
                Name = p.Name,
                SubgroupPhotoLink = p.SubgroupPhotoLink
            }).AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<Subgroup?> GetSubgroupByIdAsync(long id)
    {
        return await Subgroups
            .Where(p => p.Id == id)
            .Select(p => new Subgroup
            {
                Id = p.Id,
                GroupId = p.GroupId,
                Name = p.Name,
                SubgroupPhotoLink = p.SubgroupPhotoLink
            }).FirstOrDefaultAsync();
    }

    public async Task<Subgroup?> UpdateSubgroupAsync(Subgroup subgroup)
    {
        var entity = Subgroups.Update(subgroup);
        await CommitAsync();
        return entity.Entity;
    }

    public async Task<IReadOnlyCollection<Subgroup>> GetAllSubgroupsByGroupIdAsync(long groupId)
    {
        return await Subgroups
            .Where(p => p.GroupId == groupId)
            .Select(p => new Subgroup
            {
                Id = p.Id,
                GroupId = p.GroupId,
                Name = p.Name,
                SubgroupPhotoLink = p.SubgroupPhotoLink
            }).AsNoTracking()
            .ToArrayAsync();
    }
}