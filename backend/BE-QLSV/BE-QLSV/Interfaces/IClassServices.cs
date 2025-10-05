using BE_QLSV.Models;

namespace BE_QLSV.Interfaces
{
    public interface IClassServices
    {
        Task<IEnumerable<Classes>> GetAllClassesAsync();
        Task<Classes> GetClassByIdAync(Guid classId);
        Task<Classes> AddClassAsync(Classes classes);
        Task<Classes> UpdateClassAsync(Guid classId, Classes classes);
        Task DeleteClassAsync(Guid classId);
    }
}
