using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using BE_QLSV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturerServices _lecturerServices;
        public LecturerController(ILecturerServices lecturerServices)
        {
            _lecturerServices = lecturerServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLecturers()
        {
            var lecturers = await _lecturerServices.GetAllLecturersAsync();
            return Ok(lecturers);
        }
        [HttpGet("{lecturerId}")]
        public async Task<IActionResult> GetLecturerById(Guid lecturerId)
        {
            var lecturer = await _lecturerServices.GetLecturerByIdAsync(lecturerId);
            if (lecturer == null)
            {
                return NotFound("Giảng viên không tồn tại");
            }
            return Ok(lecturer);
        }
        [HttpPost]
        public async Task<IActionResult> AddLecturer([FromBody] Lecturer lecturer)
        {
            if (lecturer == null)
            {
                return BadRequest("Dữ liệu giảng viên không hợp lệ");
            }
            var createdLecturer = await _lecturerServices.AddLecturerAsync(lecturer);
            return CreatedAtAction(nameof(GetLecturerById), new { lecturerId = createdLecturer.LecturerId }, createdLecturer);
        }
        [HttpPut("{lecturerId}")]
        public async Task<IActionResult> UpdateLecturer(Guid lecturerId, [FromBody] Lecturer lecturer)
        {
            if (lecturer == null)
            {
                return BadRequest("Dữ liệu giảng viên không hợp lệ");
            }
            var updatedLecturer = await _lecturerServices.UpdateLecturerAsync(lecturerId, lecturer);
            if (updatedLecturer == null)
            {
                return NotFound("Giảng viên không tồn tại");
            }
            return Ok(updatedLecturer);
        }
        [HttpDelete("{lecturerId}")]
        public async Task<IActionResult> DeleteLecturer(Guid lecturerId)
        {
            try
            {
                await _lecturerServices.DeleteLecturerAsync(lecturerId);
                return Ok("Xoá giảng viên thành công");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Giảng viên không tồn tại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Xóa giảng viên thất bại: {ex.Message}");
            }
            
        }

    }
}
