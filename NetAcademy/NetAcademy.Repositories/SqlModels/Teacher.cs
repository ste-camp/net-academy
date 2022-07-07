using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAcademy.Repositories.SqlModels;

internal class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string TeacherName { get; set; } = null!;
    public string TeacherSurname { get; set; } = null!;
    public string TeacherEmail { get; set; } = null!;

    //Navigation Property
    public virtual ICollection<Course>? Courses { get; set; }
}
