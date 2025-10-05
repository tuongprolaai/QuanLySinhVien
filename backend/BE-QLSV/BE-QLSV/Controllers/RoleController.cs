using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using BE_QLSV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleServices.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{RoleId}")]
        public async Task<IActionResult> GetRoleById(Guid RoleId)
        {
            var role = await _roleServices.GetRolesByIdAsync(RoleId);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Role không được trống");
            }
            var createdRole = await _roleServices.AddRolesAsync(role);
            return CreatedAtAction(nameof(GetRoleById), new { RoleId = createdRole.RoleId }, createdRole);
        }

        [HttpPut("{RoleId}")]
        public async Task<IActionResult> UpdateRole(Guid id, [FromBody] Role role)
        {
            if (role == null || id != role.RoleId)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            var updatedRole = await _roleServices.UpdateRolesAsync(id, role);
            if (updatedRole == null)
            {
                return NotFound();
            }
            return Ok(updatedRole);
        }

        [HttpDelete("{RoleId}")]
        public async Task<IActionResult> DeleteRole(Guid RoleId)
        {
            try
            {
                await _roleServices.DeleteRolesAsync(RoleId);
                return Ok("Xoá Role thành công");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Role không tồn tại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Xoá Role thất bại: {ex.Message}");
            }
        }
    }
}
