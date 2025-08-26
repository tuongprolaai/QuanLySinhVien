using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using BE_QLSV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _studentServices.GetAllStudentAsync();
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            var student = await _studentServices.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Sinh viên null");
            }
            var createdStudent = await _studentServices.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { studentId = createdStudent.StudentId }, createdStudent);
        }
        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            try
            {
                var updatedStudent = await _studentServices.UpdateStudentAsync(studentId, student);
                return Ok(updatedStudent);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            try
            {
                await _studentServices.DeleteStudentAsync(studentId);
                return Ok("Xoá sinh viên thành công");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Sinh viên không tồn tại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Xoá sinh viên thất bại: {ex.Message}");
            }
        }
    }
}
