using System;

namespace NetAcademy.Repositories.SqlModels;

internal class Teacher
{
    public string TeacherId { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Office { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<Course>? Courses { get; set; }
}