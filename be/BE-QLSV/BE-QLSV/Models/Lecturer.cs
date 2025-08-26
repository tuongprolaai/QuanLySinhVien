using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace BE_QLSV.Models
{
    public class Lecturer
    {
        [Key]
        public Guid LecturerId { get; set; }

        [Required]
        [StringLength(20)]
        public string LecturerCode { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public LecturerGender Gender { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        public LecturerStatus IsActive { get; set; }

        public int? AccountId { get; set; }  
        public Account? Account { get; set; }  

        // 1 giảng viên có thể cố vấn nhiều lớp
        [InverseProperty("HeadTeacher")]
        public ICollection<Classes> HeadClasses { get; set; } = new List<Classes>();

        // 1 giang viên có thể dạy nhiều môn học
        public ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();


    }
    public enum LecturerGender
    {
        Female = 0,
        Male = 1,
    }
    public enum LecturerStatus
    {
        Active = 0, // dạy
        Inactive = 1, // không giảng dạy
        Retired = 2, // nghỉ hưu
        Resigned = 3 // từ chức

    }
}
