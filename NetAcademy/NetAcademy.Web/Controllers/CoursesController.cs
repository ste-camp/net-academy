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

    public CoursesController(ILogger<CoursesController> l, CoursesService s)
    {
        logger = l;
        service = s;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDto>> GetCourse([FromRoute] long id)
    {
        var course = await service.GetCourseAsync(id);
        if (course == null)
        {
            return StatusCode(404);
        }
        else
        {
            return course;
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> AddCourse([FromBody] CourseDto? data)
    {
        if (data != null)
        {
            await service.CreateNewCourseAsync(data);
            return StatusCode(200);
        }
        else
        {
            return StatusCode(400);
        }
    }

    [HttpGet("")]
    public async Task<List<CourseDto>> GetAllCourses(string category)
    {
        return await service.GetAllCoursesAsync(category);
    }
}