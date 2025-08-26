using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BE_QLSV.Models
{
    public class Grade
    {
        [Key]
        public Guid GradeId { get; set; }

        public double? AttendanceScore { get; set; }
        public double? MidtermScore { get; set; }
        public double? FinalScore { get; set; }
        public double? OverallScore { get; set; }
        [JsonIgnore]
        public Guid StudentId { get; set; }
        public Student? Student { get; set; }

        public Guid CourseSectionId { get; set; }
        [JsonIgnore]
        public CourseSection? CourseSection { get; set; }
    }
}
