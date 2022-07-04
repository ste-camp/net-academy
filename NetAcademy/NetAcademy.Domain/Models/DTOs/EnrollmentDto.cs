namespace NetAcademy.Domain.Models.DTOs;

public class EnrollmentDto : CourseDto
{
    public long EnrollmentId { get; set; } 
    public char Grade { get; set; }
}
