using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    private ILogger<CoursesController> logger;
    private CoursesService service;

    public CoursesController(ILogger<CoursesController> log, CoursesService s)
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
    public async Task<List<CourseDto>> GetAllCoursesAsync(string? category)
    {
        return await service.GetAllCoursesAsync(category);
    }

    [HttpGet("/categories")]
    public List<string> GetAllCoursesCategory()
    {
        return service.GetAllCoursesCategory();
    }

    [HttpGet("/summaries")]
    public List<string> GetAllCoursesSummary()
    {
        throw new NotImplementedException();
    }
}