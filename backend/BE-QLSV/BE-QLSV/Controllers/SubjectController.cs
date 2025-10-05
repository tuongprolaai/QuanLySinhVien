using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;
        public SubjectController(ISubjectServices subjectServices)
        {
            _subjectServices = subjectServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var subjects = await _subjectServices.GetAllSubjectsAsync();
            return Ok(subjects);
        }
        [HttpGet("{subjectId}")]
        public async Task<IActionResult> GetSubjectById(Guid subjectId)
        {
            try
            {
                var subject = await _subjectServices.GetSubjectByIdAsync(subjectId);
                return Ok(subject);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Môn học không tồn tại");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddSubject([FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("Môn học không được trống");
            }
            try
            {
                var createdSubject = await _subjectServices.AddSubjectAsync(subject);
                return CreatedAtAction(nameof(GetSubjectById), new { subjectId = createdSubject.SubjectId }, createdSubject);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
        [HttpPut("{subjectId}")]
        public async Task<IActionResult> UpdateSubject(Guid subjectId, [FromBody] Subject subject)
        {
            if (subject == null)
            {
                return BadRequest("Dữ liệu không hợp lệ");
            }
            try
            {
                subject.SubjectId = subjectId;
                var updatedSubject = await _subjectServices.UpdateSubjectAsync(subjectId, subject);
                return Ok(updatedSubject);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Môn học không tồn tại");
            }
        }
        [HttpDelete("{subjectId}")]
        public async Task<IActionResult> DeleteSubject(Guid subjectId)
        {
            try
            {
                await _subjectServices.DeleteSubjectAsync(subjectId);
                return Ok("Xoá môn học thành công");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Môn học không tồn tại");
            }
            catch (Exception ex)
            {
                return BadRequest($"Xóa môn học thất bại: {ex.Message}");
            }
        }
    }
}
