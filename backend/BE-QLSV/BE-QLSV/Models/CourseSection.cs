using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BE_QLSV.Models
{
    public class CourseSection
    {
        [Key]
        public Guid CourseSectionId { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        [StringLength(20)]
        public string Year { get; set; }    

        public Guid LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid ClassId { get; set; }
        public Classes Class { get; set; }

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
