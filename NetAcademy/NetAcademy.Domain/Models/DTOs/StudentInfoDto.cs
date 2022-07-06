namespace NetAcademy.Domain.Models.DTOs;

public class StudentInfoDto : StudentDto
{
    public List<StudentCourseDto>? StudentCourses { get; set; } = null!;
    public List<StudentCourseInfoDto>? StudentCoursesInfo { get; set; } = null!;
}
