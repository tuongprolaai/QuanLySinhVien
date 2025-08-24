using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_QLSV.Services
{
    public class ClassServices : IClassServices
    {
        private readonly StudentManagerDbContext _context;
        public ClassServices(StudentManagerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Classes>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }
        public async Task<Classes> GetClassByIdAync(Guid classId)
        {
            return await _context.Classes.FindAsync(classId) ?? throw new KeyNotFoundException("Không tìm thấy lớp học");
        }
        public async Task<Classes> AddClassAsync(Classes classes)
        {
            if (classes == null)
            {
                throw new ArgumentNullException(nameof(classes), "Lớp học không được trống");
            }
            var existingClass = await _context.Classes.FirstOrDefaultAsync(c => c.ClassName == classes.ClassName);

            if (existingClass != null)
            {
                throw new Exception($"Lớp học '{classes.ClassName}' đã tồn tại!");
            }
            _context.Classes.Add(classes);
            await _context.SaveChangesAsync();
            return classes;
        }
        public async Task<Classes> UpdateClassAsync(Guid classId, Classes classes)
        {
            if (classes == null)
            {
                throw new ArgumentNullException(nameof(classes), "Lớp học không được trống");
            }
            var existingClass = await _context.Classes.FindAsync(classId);
            if (existingClass == null)
            {
                throw new KeyNotFoundException("Lớp học không tồn tại");
            }
            existingClass.ClassName = classes.ClassName;
            existingClass.SchoolYear = classes.SchoolYear;
            existingClass.HeadTeacherId = classes.HeadTeacherId;
            _context.Classes.Update(existingClass);
            await _context.SaveChangesAsync();
            return existingClass;
        }
        public async Task DeleteClassAsync(Guid classId)
        {
            var classes = await _context.Classes.FindAsync(classId);
            if (classes == null)
            {
                throw new KeyNotFoundException("Lớp học không tồn tại");
            }
            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();
        }
    }
}
