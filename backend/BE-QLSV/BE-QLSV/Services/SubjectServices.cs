using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_QLSV.Services
{
    public class SubjectServices : ISubjectServices
    {
        private readonly StudentManagerDbContext _context;
        public SubjectServices(StudentManagerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<Subject> GetSubjectByIdAsync(Guid subjectId)
        {
            return await _context.Subjects.FindAsync(subjectId) ?? throw new KeyNotFoundException("Không tìm thấy môn học");
        }
        public async Task<Subject> AddSubjectAsync(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject), "Môn học không được trống");
            }
            var existingSubject = await _context.Subjects.FirstOrDefaultAsync(s => s.SubjectName == subject.SubjectName);

            if (existingSubject != null)
            {
                throw new Exception($"Môn học '{subject.SubjectName}' đã tồn tại!");
            }
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return subject;
        }
        public async Task<Subject> UpdateSubjectAsync(Guid subjectId, Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject), "Môn học không được trống");
            }
            var existingSubject = await _context.Subjects.FindAsync(subjectId);
            if (existingSubject == null)
            {
                throw new KeyNotFoundException("Môn học không tồn tại");
            }
            existingSubject.SubjectName = subject.SubjectName;
            existingSubject.SubjectCode = subject.SubjectCode;
            existingSubject.Credits = subject.Credits;
            _context.Subjects.Update(existingSubject);
            await _context.SaveChangesAsync();
            return existingSubject;
        }
        public async Task DeleteSubjectAsync(Guid subjectId)
        {
            var subject = await _context.Subjects.FindAsync(subjectId);
            if (subject == null)
            {
                throw new KeyNotFoundException("Môn học không tồn tại");
            }
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }
    }
}
