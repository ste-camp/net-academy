using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAcademy.Repositories.SqlModels;

internal class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string StudentName { get; set; } = null!;
    public string StudentSurname { get; set; } = null!;
    public string StudentEmail { get; set; } = null!;
    public virtual ICollection<Enrollment>? Enrollments { get; set; }
}
