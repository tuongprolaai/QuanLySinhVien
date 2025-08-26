using BE_QLSV.Models;

namespace BE_QLSV.Interfaces
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(Guid studentId);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(Guid studentId, Student student);
        Task<Student> DeleteStudentAsync(Guid studentId);
    }
}
