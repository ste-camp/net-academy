namespace NetAcademy.Repositories.SqlModels;

internal class StudentCourse
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }

    //Navigation Properties
    public virtual Student Student { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;
}
