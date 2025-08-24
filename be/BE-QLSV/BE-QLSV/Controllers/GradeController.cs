using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BE_QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeServices _gradeServices;

        public GradeController(IGradeServices gradeServices)
        {
            _gradeServices = gradeServices;
        }

        // Lấy điểm theo GradeId
        [HttpGet("{gradeId}")]
        public async Task<IActionResult> GetGradeById(Guid gradeId)
        {
            try
            {
                var grade = await _gradeServices.GetGradeByIdAsync(gradeId);
                return Ok(grade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Điểm số không tồn tại");
            }
        }

        // Lấy điểm theo studentId và courseSectionId (xem điểm học sinh theo học phần)
        [HttpGet("student/{studentId}/course/{courseSectionId}")]
        public async Task<IActionResult> GetGradeByStudentAndCourse(Guid studentId, Guid courseSectionId)
        {
            try
            {
                var grade = await _gradeServices.GetGradeByStudentAndCourseSectionAsync(studentId, courseSectionId);
                return Ok(grade);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Điểm số không tồn tại");
            }
        }

        // Nhập điểm (tạo mới hoặc cập nhật)
        [HttpPost]
        public async Task<IActionResult> EnterGrade([FromBody] Grade grade)
        {
            if (grade == null)
            {
                return BadRequest("Dữ liệu điểm không được trống");
            }
            try
            {
                var savedGrade = await _gradeServices.AddOrUpdateGradeAsync(grade);
                return Ok(savedGrade);
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi khi lưu điểm: {ex.Message}");
            }
        }
    }
}
