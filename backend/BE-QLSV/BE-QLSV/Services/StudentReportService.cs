    using BE_QLSV.Data;
    using BE_QLSV.Models;
    using Microsoft.AspNetCore.Mvc;
    using ClosedXML.Excel;
    using Microsoft.EntityFrameworkCore;
    using System.IO;
    using System.Threading.Tasks;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BE_QLSV.Interfaces;

namespace BE_QLSV.Services
{
        public class StudentReportService : IStudentReportService
    {
            private readonly StudentManagerDbContext _context;

            public StudentReportService(StudentManagerDbContext context)
            {
                _context = context;
            }

            public async Task<FileContentResult> ExportStudentsByClassAsync(Guid classId)
            {
                var @class = await _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefaultAsync(c => c.ClassId == classId);

                if (@class == null || @class.Students == null)
                    throw new Exception("Không tìm thấy lớp hoặc lớp không có sinh viên.");

                var stream = GenerateStudentExcel(@class.Students.ToList(), @class.ClassName, @class.SchoolYear);
                var fileName = $"DSSV_Lop_{@class.ClassName}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

                return new FileContentResult(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = fileName
                };
            }

            public async Task<FileContentResult> ExportStudentsBySchoolYearAsync(string schoolYear)
            {
                var students = await _context.Students
                    .Include(s => s.Class)
                    .Where(s => s.Class != null && s.Class.SchoolYear == schoolYear)
                    .ToListAsync();

                if (!students.Any())
                    throw new Exception("Không tìm thấy sinh viên trong khóa học này.");

                var stream = GenerateStudentExcel(students, "TatCaLop", schoolYear);
                var fileName = $"DSSV_Khoa_{schoolYear}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

                return new FileContentResult(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = fileName
                };
            }

            private MemoryStream GenerateStudentExcel(List<Student> students, string className, string schoolYear)
            {
                var stream = new MemoryStream();
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Students");

                worksheet.Cell(1, 1).Value = "STT";
                worksheet.Cell(1, 2).Value = "Mã SV";
                worksheet.Cell(1, 3).Value = "Họ tên";
                worksheet.Cell(1, 4).Value = "Ngày sinh";
                worksheet.Cell(1, 5).Value = "Giới tính";
                worksheet.Cell(1, 6).Value = "Số điện thoại";
                worksheet.Cell(1, 7).Value = "Lớp";
                worksheet.Cell(1, 8).Value = "Khóa";
                worksheet.Cell(1, 9).Value = "Trạng thái";

                int row = 2, stt = 1;
                foreach (var s in students)
                {
                    worksheet.Cell(row, 1).Value = stt++;
                    worksheet.Cell(row, 2).Value = s.StudentCode;
                    worksheet.Cell(row, 3).Value = s.FullName;
                    worksheet.Cell(row, 4).Value = s.DateOfBirth?.ToString("dd/MM/yyyy");
                    worksheet.Cell(row, 5).Value = s.Gender == StudentGender.Male ? "Nam" : "Nữ";
                    worksheet.Cell(row, 6).Value = s.PhoneNumber;
                    worksheet.Cell(row, 7).Value = s.Class?.ClassName;
                    worksheet.Cell(row, 8).Value = s.Class?.SchoolYear;
                    worksheet.Cell(row, 9).Value = s.IsActive.ToString();
                    row++;
                }

                workbook.SaveAs(stream);
                stream.Position = 0;
                return stream;
            }

            public async Task<FileContentResult> ExportStudentGradesAsync(Guid studentId)
            {
                var student = await _context.Students
                    .Include(s => s.Grades)
                        .ThenInclude(g => g.CourseSection)
                            .ThenInclude(cs => cs.Subject)  // Include môn học đúng
                    .FirstOrDefaultAsync(s => s.StudentId == studentId);

                if (student == null)
                    throw new Exception("Không tìm thấy sinh viên.");

                if (student.Grades == null || !student.Grades.Any())
                    throw new Exception("Sinh viên chưa có điểm.");

                var stream = new MemoryStream();
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Grades");

                worksheet.Cell(1, 1).Value = "STT";
                worksheet.Cell(1, 2).Value = "Mã môn học";
                worksheet.Cell(1, 3).Value = "Tên môn học";
                worksheet.Cell(1, 4).Value = "Điểm chuyên cần";
                worksheet.Cell(1, 5).Value = "Điểm giữa kỳ";
                worksheet.Cell(1, 6).Value = "Điểm cuối kỳ";
                worksheet.Cell(1, 7).Value = "Điểm tổng kết";

                int row = 2, stt = 1;
                foreach (var grade in student.Grades)
                {
                    worksheet.Cell(row, 1).Value = stt++;
                    worksheet.Cell(row, 2).Value = grade.CourseSection?.Subject?.SubjectCode ?? "";
                    worksheet.Cell(row, 3).Value = grade.CourseSection?.Subject?.SubjectName ?? "";
                    worksheet.Cell(row, 4).Value = grade.AttendanceScore ?? 0;
                    worksheet.Cell(row, 5).Value = grade.MidtermScore ?? 0;
                    worksheet.Cell(row, 6).Value = grade.FinalScore ?? 0;
                    worksheet.Cell(row, 7).Value = grade.OverallScore ?? 0;
                    row++;
                }

                workbook.SaveAs(stream);
                stream.Position = 0;

                var fileName = $"BaoCaoDiem_{student.StudentCode}_{DateTime.Now:yyyyMMddHHmmss}.xlsx";

                return new FileContentResult(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = fileName
                };
            }
        }
    }
