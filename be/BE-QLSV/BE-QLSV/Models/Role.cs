using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BE_QLSV.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
