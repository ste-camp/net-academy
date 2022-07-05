using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TeachersController : ControllerBase
{
    private ILogger<TeachersController> logger;
    private TeachersService service;

    public TeachersController(ILogger<TeachersController> log, TeachersService s)
    {
        logger = log;
        service = s;
    }

    [HttpGet("{id}")]
    public async Task<TeacherDto?> GetTeacherAsync(long id)
    {
        return await service.GetTeacherAsync(id);
    }

    [HttpPut("{id}")]
    public async Task UpdateTeacherAsync(long id, TeacherDto dto)
    {
        await service.UpdateTeacherAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteTeacherAsync(long id)
    {
        await service.DeleteTeacherAsync(id);
    }

    [HttpGet("")]
    public List<TeacherDto> GetAllTeachers()
    {
        return service.GetAllTeachers();
    }

    [HttpPost("")]
    public async Task CreateNewTeacherAsync(TeacherDto dto)
    {
        await service.CreateNewTeacherAsync(dto);
    }

    [HttpGet("course")]
    public List<TeacherInfoDto> GetTeachersAndCourses()
    {
        return service.GetTeachersAndCourses();
    }

}