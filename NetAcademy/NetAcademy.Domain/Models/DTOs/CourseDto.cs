namespace NetAcademy.Domain.Models.DTOs;

public class CourseDto
{
    public long CourseId { get; set; }
    public string CourseName { get; set; } = null!;
    public string CourseCategory { get; set; } = null!;
    public DateTimeOffset CourseDate { get; set; }
    public long TeacherId { get; set; }
}
