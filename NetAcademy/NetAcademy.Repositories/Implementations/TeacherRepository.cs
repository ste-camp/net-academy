using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Repository.Implementations;

public class TeacherRepository : ITeacherRepository
{
    private ILogger<TeacherRepository> logger;
    private SchoolContext context;

    public TeacherRepository(ILogger<TeacherRepository> l, SchoolContext c)
    {
        logger = l;
        context = c;
    }

    public async Task CreateNewTeacherAsync(TeacherDto dto)
    {
        await context.Teachers.AddAsync(dto.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(long id)
    {
        Teacher teacher = await context.Teachers.FindAsync(id);
        context.Teachers.Remove(teacher);
        await context.SaveChangesAsync();
    }

    public List<TeacherDto> GetAllTeachers()
    {
        return context.Teachers.Select(x => x.ToDto()).ToList();
    }

    public async Task<TeacherDto> GetTeacherAsync(long id)
    {
        Teacher teacher = await context.Teachers.FindAsync(id);
        return teacher.ToDto();
    }

    public async Task UpdateTeacherAsync(long id, TeacherDto dto)
    {
        Teacher teacher = await context.Teachers.FindAsync(id);
        teacher.TeacherName = dto.TeacherName;
        teacher.TeacherSurname = dto.TeacherSurname;
        teacher.TeacherEmail = dto.TeacherEmail;

        await context.SaveChangesAsync();
    }

    public List<TeacherInfoDto> GetTeachersAndCourses()
    {
        return context
            .Teachers
            .Include(t => t.Courses)
            .Select(x =>
            new TeacherInfoDto()
            {
                Courses = x.Courses.Select(c => c.ToDto()).ToList(),
                TeacherEmail = x.TeacherEmail,
                TeacherName = x.TeacherName,
                TeacherSurname = x.TeacherSurname,
                TeacherId = x.Id
            })
            .ToList();
    }
}