namespace NetAcademy.Domain.Models.DTOs;

public class CourseInfoDto : CourseDto
{
    public TeacherDto Teacher { get; set; }
}
