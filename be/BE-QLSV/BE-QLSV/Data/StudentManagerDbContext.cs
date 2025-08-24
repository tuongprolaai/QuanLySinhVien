using BE_QLSV.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BE_QLSV.Data
{
    public class StudentManagerDbContext : DbContext
    {
        public StudentManagerDbContext(DbContextOptions<StudentManagerDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<Lecturer>().HasIndex(l => l.LecturerCode).IsUnique();
            modelBuilder.Entity<Student>().HasIndex(s => s.StudentCode).IsUnique();
            modelBuilder.Entity<Subject>().HasIndex(s => s.SubjectCode).IsUnique();

            modelBuilder.Entity<Account>()
                .HasOne(u => u.Student)
                .WithOne(s => s.Account)
                .HasForeignKey<Student>(s => s.AccountId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Account>()
                .HasOne(u => u.Lecturer)
                .WithOne(l => l.Account)
                .HasForeignKey<Lecturer>(l => l.AccountId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Classes>()
                .HasOne(c => c.HeadTeacher)
                .WithMany(l => l.HeadClasses)
                .HasForeignKey(c => c.HeadTeacherId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
