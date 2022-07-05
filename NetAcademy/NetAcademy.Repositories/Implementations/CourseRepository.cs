using Microsoft.Extensions.Logging;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.SqlModels;
using NetAcademy.Repository.Interfaces;


namespace NetAcademy.Repository.Implementations;

public class CourseRepository : ICourseRepository
{
    private ILogger<CourseRepository> logger;
    private SchoolContext context;

    public CourseRepository(ILogger<CourseRepository> l, SchoolContext c)
    {
        logger = l;
        context = c;
    }

    public async Task CreateNewCourseAsync(CourseDto dto)
    {
        await context.Courses.AddAsync(dto.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(long id)
    {
        Course Course = await context.Courses.FindAsync(id);
        context.Courses.Remove(Course);
        await context.SaveChangesAsync();
    }

    public async Task<List<CourseDto>> GetAllCoursesAsync()
    {
        return context.Courses.Select(x => x.ToDto()).ToList();
    }

    public async Task<CourseDto> GetCourseAsync(long id)
    {
        Course course = await context.Courses.FindAsync(id);
        return course.ToDto();
    }

    public async Task UpdateCourseAsync(long id, CourseDto dto)
    {
        Course course = await context.Courses.FindAsync(id);
        course.CourseName = dto.CourseName;
        course.CourseCategory = dto.CourseCategory;
        course.CourseDate = dto.CourseDate;
        await context.SaveChangesAsync();
    }

    public List<string> GetAllCoursesCategory()
    {
        return context.Courses.Select(x => x.CourseCategory).ToList();
    }

    public List<CourseDto> GetCoursesByCategory(string category)
    {
        return context.Courses.Where(x => x.CourseCategory == category).Select(x => x.ToDto()).ToList();
    }
}