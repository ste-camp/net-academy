using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.Interfaces;

namespace NetAcademy.Services;

public class CoursesService
{
    private ICoursesRepository repository;

    public CoursesService(ICoursesRepository repo)
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

    public async Task<List<CourseDto>> GetAllCoursesAsync(string? category)
    {
        if (category is null)
        {
            return await repository.GetAllCoursesAsync();
        }
        else
        {
            return repository.GetCoursesByCategory(category);
        }
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
}