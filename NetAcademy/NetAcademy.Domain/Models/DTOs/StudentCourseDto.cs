namespace NetAcademy.Domain.Models.DTOs;

public class StudentCourseDto
{
    public long StudentId { get; set; }
    public long CourseId { get; set; }
    public CourseDto? Course { get; set; }
}

