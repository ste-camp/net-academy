using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class CourseService
{
    private ICourseRepository repository;

    public CourseService(ICourseRepository repo)
    {
        repository = repo;
    }

    public async Task CreateNewCourseAsync(CourseDto dto)
    {
        await repository.CreateNewCourseAsync(dto);
    }

    public async Task UpdateCourseAsync(long id, CourseDto dto)
    {
        await repository.UpdateCourseAsync(id, dto);
    }

    public async Task<List<CourseDto>> GetAllCoursesAsync()
    {
        return await repository.GetAllCoursesAsync();
    }

    public async Task<CourseDto?> GetCourseAsync(long id)
    {
        return await repository.GetCourseAsync(id);
    }

    public async Task DeleteCourseAsync(long id)
    {
        await repository.DeleteCourseAsync(id);
    }

    public List<string> GetAllCoursesCategory()
    {
        return repository.GetAllCoursesCategory();
    }

    public List<CourseDto> GetCoursesByCategory(string category)
    {
        return repository.GetCoursesByCategory(category);
    }
}