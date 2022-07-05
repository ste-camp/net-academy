namespace NetAcademy.Domain.Models.DTOs;

public class StudentInfoDto : StudentDto
{
    public List<StudentCourseDto>? StudentCourses { get; set; } = null!;
}
