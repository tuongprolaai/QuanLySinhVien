using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BE_QLSV.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentCode { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public StudentGender Gender { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }
        public StudentStatus IsActive { get; set; }

        public Guid? AccountId { get; set; }
        
        public Account? Account { get; set; }

        public Guid? ClassId { get; set; }
        public Classes? Class { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();

    }
    public enum StudentGender
    {
        Female = 0,
        Male = 1,
    }
    public enum StudentStatus
    {
        Enrolled = 0, // đang học
        Suspended = 1, // bảo lưu
        Graduated = 2, // tốt nghiệp
        DroppedOut = 3 // thôi học
    }
}
