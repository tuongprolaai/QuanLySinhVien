using Microsoft.AspNetCore.Mvc;
using BE_QLSV.Interfaces;
namespace BE_QLSV.Controllers
{
    public class StudentReportsController : Controller
    {
        [ApiController]
        [Route("api/reports/students")]
        public class StudentReportController : ControllerBase
        {
            private readonly IStudentReportService _reportService;

            public StudentReportController(IStudentReportService reportService)
            {
                _reportService = reportService;
            }

            [HttpGet("by-class/{classId}")]
            public async Task<IActionResult> ExportByClass(Guid classId)
            {
                try
                {
                    var result = await _reportService.ExportStudentsByClassAsync(classId);
                    return result;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpGet("by-year/{schoolYear}")]
            public async Task<IActionResult> ExportBySchoolYear(string schoolYear)
            {
                try
                {
                    var result = await _reportService.ExportStudentsBySchoolYearAsync(schoolYear);
                    return result;
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}