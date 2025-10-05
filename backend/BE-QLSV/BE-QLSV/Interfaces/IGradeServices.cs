using BE_QLSV.Models;
using System;
using System.Threading.Tasks;

namespace BE_QLSV.Interfaces
{
    public interface IGradeServices
    {

        Task<Grade> GetGradeByIdAsync(Guid gradeId);
        Task<Grade> GetGradeByStudentAndCourseSectionAsync(Guid studentId, Guid courseSectionId);
        Task<Grade> AddOrUpdateGradeAsync(Grade grade);
    }
}
