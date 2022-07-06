using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class StudentsRepository : IStudentsRepository
{
    private ILogger<StudentsRepository> logger;
    private SchoolContext context;

    public StudentsRepository(ILogger<StudentsRepository> l, SchoolContext c)
    {
        logger = l;
        context = c;
    }

    public async Task EnrollStudentToCourseAsync(long id, long courseId)
    {
        StudentCourse studentCourse = new() { StudentId = id, CourseId = courseId };
        await context.StudentsCourses.AddAsync(studentCourse);
        await context.SaveChangesAsync();

        //or
        //Student student = await context.Students.Include(s => s.StudentCourses).FirstOrDefaultAsync(s => s.Id == id);
        //student.StudentCourses.Add(new() { CourseId = courseId, StudentId = id });
        //context.SaveChangesAsync();

        //or
        //Course course = await context.Courses.FindAsync(courseId);
        //course.StudentCourses.Add(new() { CourseId = courseId, StudentId = id });
        //context.SaveChangesAsync();
    }

    public async Task<StudentInfoDto> GetStudentCourseAsync(long id)
    {
        Student student = await context
            .Students
            .Include(x => x.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .FirstOrDefaultAsync(x => x.Id == id);

        //Student student = await (from s in context.Students
        //                   join sc in context.StudentsCourses on s.Id equals sc.StudentId
        //                   join c in context.Courses on sc.CourseId equals c.Id
        //                   select s)
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



    public async Task<StudentInfoDto> GetStudentCoursesAndTeachersAsync(long id)
    {
        Student student = await context
            .Students
            .Include(s => s.StudentCourses)
            .ThenInclude(sc => sc.Course)
            .ThenInclude(sc => sc.Teacher)
            .FirstOrDefaultAsync(x => x.Id == id);

        StudentDto dto = student.ToDto();
        StudentInfoDto info = new();
        info.StudentId = dto.StudentId;
        info.StudentName = dto.StudentName;
        info.StudentSurname = dto.StudentSurname;
        info.StudentEmail = dto.StudentEmail;
        info.StudentCoursesInfo = student.StudentCourses.Select(x => x.ToInfoDto()).ToList();

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

    public async Task CancelStudentFromCourseAsync(long id, long courseId)
    {
        StudentCourse studentCourse = new() { StudentId = id, CourseId = courseId };
        context.StudentsCourses.Remove(studentCourse);
        await context.SaveChangesAsync();
    }
}