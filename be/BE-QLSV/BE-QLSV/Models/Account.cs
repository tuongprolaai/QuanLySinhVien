using System.ComponentModel.DataAnnotations;

namespace BE_QLSV.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }

        [Required]
        [StringLength(20)]         
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public Student? Student { get; set; }
        public Lecturer? Lecturer { get; set; }

    }
}
