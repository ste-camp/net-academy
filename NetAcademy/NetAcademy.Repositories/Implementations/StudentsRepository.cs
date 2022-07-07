using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.Interfaces;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories.Implementations;

public class StudentsRepository : IStudentsRepository
{
    private ILogger<StudentsRepository> logger;
    private SchoolContext context;

    public StudentsRepository(ILogger<StudentsRepository> l, SchoolContext c)
    {
        logger = l;
        context = c;
    }

    public Task CancelStudentFromCourseAsync(long id, long courseId)
    {
        throw new NotImplementedException();
    }

    public Task CreateNewStudentAsync(StudentDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudentAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task EnrollStudentToCourseAsync(long id, long courseId)
    {
        throw new NotImplementedException();
    }

    public Task<List<StudentDto>> GetAllStudentsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudentDto> GetStudentAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<StudentInfoDto> GetStudentCourseAsync(long id)
    {
        Student student = await context
            .Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefaultAsync(x => x.Id == id);

        //Student student = await (from s in context.Students
        //                         join sc in context.StudentsCourses on s.Id equals sc.StudentId
        //                         join c in context.Courses on sc.CourseId equals c.Id
        //                         select s)
        //                   .Include(s => s.StudentCourses)
        //                   .FirstOrDefaultAsync();

        StudentDto dto = student.ToDto();
        StudentInfoDto info = new();
        info.StudentId = dto.StudentId;
        info.StudentName = dto.StudentName;
        info.StudentSurname = dto.StudentSurname;
        info.StudentEmail = dto.StudentEmail;
        info.StudentCourses = student.StudentCourses.Select(x => x.ToDto()).ToList();

        return info;
    }

    public Task<StudentInfoDto> GetStudentCoursesAndTeachersAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateStudentAsync(long id, StudentDto dto)
    {
        throw new NotImplementedException();
    }
}
