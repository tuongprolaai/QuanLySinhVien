using Microsoft.AspNetCore.Mvc;

namespace BE_QLSV.Interfaces
{
    public interface IStudentReportService
    {
        Task<FileContentResult> ExportStudentsByClassAsync(Guid classId);
        Task<FileContentResult> ExportStudentsBySchoolYearAsync(string schoolYear);
        Task<FileContentResult> ExportStudentGradesAsync(Guid studentId);
    }
}
