namespace BE_QLSV.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; 
        public string? Email { get; set; }
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Guid? StudentId { get; set; } 
        public Student? Student { get; set; }
        public Lecturer? Lecturer { get; set; }
    }
}
