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
    public long TeacherId { get; set; }

    //Navigation Properties
    public virtual ICollection<StudentCourse> StudentCourses { get; set; } = null!;
    public virtual Teacher Teacher { get; set; } = null!;
}
