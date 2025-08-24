using System.ComponentModel.DataAnnotations;

namespace BE_QLSV.Models
{
    public class Classes
    {
        [Key]
        public Guid ClassId { get; set; }

        [Required]
        [StringLength(20)]
        public string ClassName { get; set; }

        [StringLength(50)]
        public string? SchoolYear { get; set; }

        public Guid? HeadTeacherId { get; set; }
        public Lecturer? HeadTeacher { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
        public ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();


    }
}
