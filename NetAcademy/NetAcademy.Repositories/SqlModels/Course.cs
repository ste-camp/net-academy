using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAcademy.Repositories.SqlModels;

internal class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string CourseName { get; set; } = null!;
    public string CourseCategory { get; set; } = null!;
    public DateTimeOffset CourseDate { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = null!;
    public virtual ICollection<Teacher> Teachers { get; set; } = null!;
}