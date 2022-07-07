namespace NetAcademy.Domain.Models.DTOs;

public class StudentDto
{
    public long StudentId { get; set; }
    public string StudentName { get; set; } = null!;
    public string StudentSurname { get; set; } = null!;
    public string StudentEmail { get; set; } = null!;
}
