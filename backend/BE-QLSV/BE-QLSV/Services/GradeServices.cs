using BE_QLSV.Data;
using BE_QLSV.Interfaces;
using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_QLSV.Services
{
    public class GradeServices : IGradeServices
    {
        private readonly StudentManagerDbContext _context;

        public GradeServices(StudentManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Grade> GetGradeByIdAsync(Guid gradeId)
        {
            var grade = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.CourseSection)
                .FirstOrDefaultAsync(g => g.GradeId == gradeId);

            if (grade == null)
                throw new KeyNotFoundException("Điểm số không tồn tại");

            return grade;
        }

        public async Task<Grade> GetGradeByStudentAndCourseSectionAsync(Guid studentId, Guid courseSectionId)
        {
            var grade = await _context.Grades
                .FirstOrDefaultAsync(g => g.StudentId == studentId && g.CourseSectionId == courseSectionId);

            if (grade == null)
                throw new KeyNotFoundException("Điểm số không tồn tại");

            return grade;
        }

        public async Task<Grade> AddOrUpdateGradeAsync(Grade grade)
        {
            var existingGrade = await _context.Grades
                .FirstOrDefaultAsync(g => g.StudentId == grade.StudentId && g.CourseSectionId == grade.CourseSectionId);

            if (existingGrade == null)
            {
                grade.GradeId = Guid.NewGuid();
                _context.Grades.Add(grade);
            }
            else
            {
                existingGrade.AttendanceScore = grade.AttendanceScore;
                existingGrade.MidtermScore = grade.MidtermScore;
                existingGrade.FinalScore = grade.FinalScore;
                existingGrade.OverallScore = grade.OverallScore;
            }

            await _context.SaveChangesAsync();
            return existingGrade ?? grade;
        }
    }
}
