namespace NetAcademy.Domain.Models.DTOs;

public class StudentInfoDto : StudentDto
{
    public List<EnrollmentDto>? Enrollments { get; set; } = null!;
}
