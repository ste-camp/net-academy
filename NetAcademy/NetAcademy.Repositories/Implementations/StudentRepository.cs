using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class StudentRepository : IStudentRepository
{
    private ILogger<StudentRepository> logger;
    private SchoolContext context;

    public StudentRepository(ILogger<StudentRepository> l, SchoolContext c)
    {
        logger = l;
        context = c;
    }

    public bool CreateNewStudent(StudentDto student)
    {
        context.Students.Add(student.ToSqlModel());
        context.SaveChanges();
        return true;
    }

    public async Task EnrollStudentToCourseAsync(long id, long courseId)
    {
        Enrollment enrollment = new() { StudentId = id, CourseId = courseId };
        await context.Enrollments.AddAsync(enrollment);
        await context.SaveChangesAsync();

        //await context.Entry(enrollment).ReloadAsync();

        //Student student = await context.Students.FindAsync((long)dto.id);
        //await context.Entry(student).Collection(x => x.Enrollments).LoadAsync();
        //student.Courses.Add(new Course() { Description = dto.Description, Name = dto.Name });
        //await context.SaveChangesAsync();
    }

    public async Task<StudentInfoDto> GetStudentInfoAsync(long id)
    {
        Student student = await context
            .Students
            .Include(x => x.Enrollments)
            .ThenInclude(x => x.Course)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        StudentDto dto = student.ToDto();
        StudentInfoDto info = new();
        info.StudentId = dto.StudentId;
        info.StudentName = dto.StudentName;
        info.StudentSurname = dto.StudentSurname;
        info.StudentEmail = dto.StudentEmail;
        info.Enrollments = student.Enrollments.Select(x => x.ToDto()).ToList();

        return info;
    }


    public async Task CreateNewStudentAsync(StudentDto dto)
    {
        await context.Students.AddAsync(dto.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(long id)
    {
        Student student = await context.Students.FindAsync(id);
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }

    public async Task<List<StudentDto>> GetAllStudentsAsync()
    {
        return context.Students.Select(x => x.ToDto()).ToList();
    }

    public async Task<StudentDto> GetStudentAsync(long id)
    {
        Student student = await context.Students.FindAsync(id);
        return student.ToDto();
    }

    public async Task UpdateStudentAsync(long id, StudentDto dto)
    {
        Student student = await context.Students.FindAsync(id);
        student.StudentName = dto.StudentName;
        student.StudentSurname = dto.StudentSurname;
        student.StudentEmail = dto.StudentEmail;
        await context.SaveChangesAsync();
    }

    public Task CancelStudentFromCourseAsync(long id)
    {
        throw new NotImplementedException();
    }
}