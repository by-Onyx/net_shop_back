using net_shop_back.Entities;
using net_shop_back.Services.DI;

namespace net_shop_back.Services.Core
{
    public interface IGroupsService
    {
        public Task<IReadOnlyCollection<Group>> GetAllGroupsAsync();

        public Task<Group> AddGroupAsync(string name, string? photo);
        public Task DeleteGroupAsync(long id);

        public Task<Group?> GetGroupByIdAsync(long id);
        public Task<Group?> UpdateGroupNameAsync(Group group);
    }
}
