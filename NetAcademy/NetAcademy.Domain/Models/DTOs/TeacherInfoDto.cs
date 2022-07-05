namespace NetAcademy.Domain.Models.DTOs;

public class TeacherInfoDto : TeacherDto
{
    public List<CourseDto> Courses { get; set; }
}
