using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace BE_QLSV.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly StudentManagerDbContext _context;
        public StudentServices(StudentManagerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAllStudentAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(Guid studentId)
        {
            return await _context.Students.FindAsync(studentId);
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> UpdateStudentAsync(Guid studentId, Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Sinh viên không được trống");
            }
            var existingStudent = await _context.Students.FindAsync(studentId);
            if (existingStudent == null)
            {
                throw new KeyNotFoundException("Sinh viên không tồn tại");
            }
            student.StudentId = studentId;
            existingStudent.StudentCode = student.StudentCode;
            existingStudent.FullName = student.FullName;
            existingStudent.Gender = student.Gender;
            existingStudent.Address = student.Address;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.IsActive = student.IsActive;
            existingStudent.ClassId = student.ClassId;
            await _context.SaveChangesAsync();
            return existingStudent;
        }
        public async Task<Student> DeleteStudentAsync(Guid studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                throw new KeyNotFoundException("Sinh viên không tồn tại");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
