using Microsoft.EntityFrameworkCore;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories;

public class SchoolContext : DbContext
{
    private readonly string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=NetAcademy;Trusted_Connection=True;";//connection string di default se non viene passaa da altrove

    //tabella di esempio:
    //internal DbSet<GenerationUnit> GenerationUnits { get; set; }

    internal DbSet<Student> Students { get; set; }
    internal DbSet<Teacher> Teachers { get; set; }
    internal DbSet<Course> Courses { get; set; }
    internal DbSet<StudentCourse> StudentsCourses { get; set; }

    public SchoolContext() { }

    public SchoolContext(string connStr) : this()
    {
        connectionString = connStr;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString/*, b => b.MigrationsAssembly("NetAcademy.Web")*/);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");
        modelBuilder.Entity<Teacher>().ToTable("Teacher");
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Course>().ToTable("Course");

        // create a compound key
        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId);

        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId);

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Courses)
            .WithOne(c => c.Teacher);

        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)
            .HasForeignKey(c => c.TeacherId);

        //Any additional entities' options should be declared here

        //view declaration example:
        //modelBuilder.Entity<ViewModel>().ToView("ViewName", "ViewSchema");
    }
}