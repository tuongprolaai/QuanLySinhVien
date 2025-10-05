using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_QLSV.Services
{
    public class LecturerServices : ILecturerServices
    {
        private readonly StudentManagerDbContext _context;
        public LecturerServices(StudentManagerDbContext context)
        {
            _context = context;
        }
        public async Task<List<Models.Lecturer>> GetAllLecturersAsync()
        {
            return await _context.Lecturers.ToListAsync();
        }
        public async Task<Models.Lecturer> GetLecturerByIdAsync(Guid lecturerId)
        {
            return await _context.Lecturers.FindAsync(lecturerId);
        }
        public async Task<Models.Lecturer> AddLecturerAsync(Models.Lecturer lecturer)
        {
            lecturer.LecturerId = Guid.NewGuid();
            _context.Lecturers.Add(lecturer);
            await _context.SaveChangesAsync();
            return lecturer;
        }
        public async Task<Models.Lecturer> UpdateLecturerAsync(Guid lecturerId, Models.Lecturer lecturer)
        {
            var existingLecturer = await _context.Lecturers.FindAsync(lecturerId);
            if (existingLecturer == null)
            {
                return null;
            }
            lecturer.LecturerId = lecturerId;
            existingLecturer.LecturerCode = lecturer.LecturerCode;
            existingLecturer.FullName = lecturer.FullName;
            existingLecturer.PhoneNumber = lecturer.PhoneNumber;
            existingLecturer.DateOfBirth = lecturer.DateOfBirth;
            existingLecturer.Gender = lecturer.Gender;
            existingLecturer.Address = lecturer.Address;
            existingLecturer.IsActive = lecturer.IsActive;
            await _context.SaveChangesAsync();
            return existingLecturer;
        }
        public async Task DeleteLecturerAsync(Guid lecturerId)
        {
            var lecturer = await _context.Lecturers.FindAsync(lecturerId);
            if (lecturer == null)
            {
                throw new KeyNotFoundException("Giảng viên không tồn tại");
            }
            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
        }
    }
}
