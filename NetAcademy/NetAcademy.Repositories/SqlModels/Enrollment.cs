using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetAcademy.Repositories.SqlModels;

internal class Enrollment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long CourseId { get; set; }
    public long StudentId { get; set; }
    public char Grade { get; set; }

    public virtual Course Course { get; set; } = null!;
    public virtual Student Student { get; set; } = null!;
}