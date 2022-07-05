using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private ILogger<CourseController> logger;
    private CourseService service;

    public CourseController(ILogger<CourseController> log, CourseService s)
    {
        logger = log;
        service = s;
    }

    [HttpGet("{id}")]
    public async Task<CourseDto?> GetCourseAsync(long id)
    {
        return await service.GetCourseAsync(id);
    }

    [HttpPut("{id}")]
    public async Task UpdateCourseAsync(long id, [FromBody] CourseDto dto)
    {
        await service.UpdateCourseAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteCourseAsync(long id)
    {
        await service.DeleteCourseAsync(id);
    }

    [HttpPost("")]
    public async Task CreateNewCourseAsync(CourseDto dto)
    {
        await service.CreateNewCourseAsync(dto);
    }

    [HttpGet("")]
    public async Task<List<CourseDto>> GetAllCoursesAsync()
    {
        return await service.GetAllCoursesAsync();
    }

    [HttpGet("/courseCategory")]
    public List<string> GetAllCoursesCategory()
    {
        return service.GetAllCoursesCategory();
    }

    [HttpGet("/courseByCategory")]
    public List<CourseDto> GetCoursesByCategory(string category)
    {
        return service.GetCoursesByCategory(category);
    }
}