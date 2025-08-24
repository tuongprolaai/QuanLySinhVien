using Microsoft.EntityFrameworkCore;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using BE_QLSV.Data;
namespace BE_QLSV.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly StudentManagerDbContext _context;
        public RoleServices(StudentManagerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetRolesByIdAsync(Guid roleId)
        {
            return await _context.Roles.FindAsync(roleId) ?? throw new KeyNotFoundException("Không tìm thấy Role");
        }
        public async Task<Role> AddRolesAsync(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role không được trống");
            }
            var existingRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == role.RoleName);

            if (existingRole != null)
            {
                throw new Exception($"Role '{role.RoleName}' đã tồn tại!");
            }
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> UpdateRolesAsync(Guid roleId, Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role không được trống");
            }
            var existingRole = await _context.Roles.FindAsync(roleId);
            if (existingRole == null)
            {
                throw new KeyNotFoundException("Role không tồn tại");
            }
            existingRole.RoleName = role.RoleName;
            existingRole.Description = role.Description;
            _context.Roles.Update(existingRole);
            await _context.SaveChangesAsync();
            return existingRole;
        }
        public async Task DeleteRolesAsync(Guid roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                throw new KeyNotFoundException("Role không tồn tại");
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
