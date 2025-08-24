using System.ComponentModel.DataAnnotations;

namespace BE_QLSV.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }

        [Required]
        [StringLength(20)]
        public string SubjectCode { get; set; }

        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        [Required]
        public int Credits { get; set; }

        public ICollection<CourseSection> CourseSections { get; set; } = new List<CourseSection>();
    }
}
