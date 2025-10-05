using BE_QLSV.Models;

namespace BE_QLSV.Interfaces
{
    public interface ISubjectServices
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(Guid subjectId);
        Task<Subject> AddSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(Guid subjectId, Subject subject);
        Task DeleteSubjectAsync(Guid subjectId);

    }
}
