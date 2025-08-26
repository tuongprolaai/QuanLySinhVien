using BE_QLSV.Models;

namespace BE_QLSV.Interfaces
{
    public interface ILecturerServices
    {
        Task<List<Lecturer>> GetAllLecturersAsync();
        Task<Lecturer> GetLecturerByIdAsync(Guid lecturerId);
        Task<Lecturer> AddLecturerAsync(Lecturer lecturer);
        Task<Lecturer> UpdateLecturerAsync(Guid lecturerId, Lecturer lecturer);
        Task DeleteLecturerAsync(Guid lecturerId);
    }
}
