using BE_QLSV.Models;

namespace BE_QLSV.Interfaces
{
    public interface IRoleServices
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRolesByIdAsync(Guid roleId);
        Task<Role> AddRolesAsync(Role role);
        Task<Role> UpdateRolesAsync(Guid roleId, Role role);
        Task DeleteRolesAsync(Guid roleId);
    }
}
