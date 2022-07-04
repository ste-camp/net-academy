namespace NetAcademy.Domain.Models.DTOs;

public class TeacherDto
{
    public long TeacherId { get; set; }
    public string TeacherName { get; set; } = null!;
    public string TeacherSurname { get; set; } = null!;
    public string TeacherEmail { get; set; } = null!;    
}
