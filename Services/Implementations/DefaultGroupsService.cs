using Microsoft.EntityFrameworkCore;
using net_shop_back.Data;
using net_shop_back.Entities;
using net_shop_back.Exceptions;
using net_shop_back.Models;
using net_shop_back.Services.Core;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Implementations
{
    [DefaultService]
    public class DefaultGroupsService : IGroupsService
    {
        private readonly ApplicationContext _ctx;
        private readonly ISubgroupService _subgroupService;

        public DefaultGroupsService(ApplicationContext ctx, ISubgroupService subgroupService)
        {
            _ctx = ctx;
            _subgroupService = subgroupService;
        }
        
        private DbSet<Group> Groups => _ctx.Set<Group>();
        private Task CommitAsync() => _ctx.SaveChangesAsync();

        public async Task<Group> AddGroupAsync(string name, string? photo)
        {
            var group = new Group
            {
                Name = name,
                GroupPhotoLink = photo
            };
            Groups.Add(group);
            await CommitAsync();

            return group;
        }

        public async Task DeleteGroupAsync(long id)
        {
            var group = await GetGroupByIdAsync(id);

            NotFoundException.ThrowIfNull(group);

            Groups.Remove(group);
            await CommitAsync();
        }

        public async Task<IReadOnlyCollection<Group>> GetAllGroupsAsync()
        {
            return await Groups
                .OrderBy(p => p.Id)
                .Select(p => new Group
                {
                    Name = p.Name,
                    Id = p.Id,
                    GroupPhotoLink = p.GroupPhotoLink
                }).AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Group?> GetGroupByIdAsync(long id)
        {
            return await Groups
                .Where(p => p.Id == id)
                .Select(p => new Group
                {
                    Name = p.Name,
                    Id = p.Id,
                    GroupPhotoLink = p.GroupPhotoLink
                }).FirstOrDefaultAsync();
        }

        public async Task<Group?> UpdateGroupNameAsync(Group group)
        {
            var entity = Groups.Update(group);
            await CommitAsync();
            return entity.Entity;
        }
    }
}
