using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassServices _classServices;
        public ClassController(IClassServices classServices)
        {
            _classServices = classServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _classServices.GetAllClassesAsync();
            return Ok(classes);
        }
        [HttpGet("{classId}")]
        public async Task<IActionResult> GetClassById(Guid classId)
        {
            var classes = await _classServices.GetClassByIdAync(classId);
            if (classes == null)
            {
                return NotFound();
            }
            return Ok(classes);
        }
        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] Classes classes)
        {
            if (classes == null)
            {
                return BadRequest("Lớp học không được trống");
            }
            var createdClass = await _classServices.AddClassAsync(classes);
            return CreatedAtAction(nameof(GetClassById), new { classId = createdClass.ClassId }, createdClass);
        }
        [HttpPut("{classId}")]
        public async Task<IActionResult> UpdateClass(Guid classId, [FromBody] Classes classes)
        {
            if (classes == null)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            classes.ClassId = classId;
            var updatedClass = await _classServices.UpdateClassAsync(classId, classes);
            if (updatedClass == null)
            {
                return NotFound();
            }
            return Ok(updatedClass);
        }
        [HttpDelete("{classId}")]
        public async Task<IActionResult> DeleteClass(Guid classId)
        {
            try
            {
                await _classServices.DeleteClassAsync(classId);
                return Ok("Xoá lớp học thành công");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Lớp học không tồn tại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Xóa lớp học thất bại: {ex.Message}");
            }
        }
    }
}
