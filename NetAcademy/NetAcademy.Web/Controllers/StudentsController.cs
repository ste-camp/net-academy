using Microsoft.AspNetCore.Mvc;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private ILogger<StudentsController> logger;
    private StudentsService service;

    public StudentsController(ILogger<StudentsController> log, StudentsService s)
    {
        logger = log;
        service = s;
    }

    [HttpGet("{id}")]
    public async Task<StudentDto?> GetStudentAsync(long id)
    {
        return await service.GetStudentAsync(id);
    }

    [HttpPut("{id}")]
    public async Task UpdateStudentAsync(long id, [FromBody] StudentDto dto)
    {
        await service.UpdateStudentAsync(id, dto);
    }

    [HttpDelete("{id}")]
    public async Task DeleteStudentAsync(long id)
    {
        await service.DeleteStudentAsync(id);
    }

    [HttpDelete("{id}/disenroll/")]
    public async Task CancelStudentFromCourseAsync(long id, long courseId)
    {
        await service.CancelStudentFromCourseAsync(id, courseId);
    }

    [HttpPost("{id}/enroll")]
    public async Task EnrollStudentToCourseAsync(long id, long courseId)
    {
        await service.EnrollStudentToCourseAsync(id, courseId);
    }

    [HttpGet("{id}/info")]
    public async Task<StudentInfoDto> GetStudentInfoAsync(long id)
    {
        return await service.GetStudentInfoAsync(id);
    }

    [HttpGet("")]
    public async Task<List<StudentDto>> GetAllStudentsAsync()
    {
        return await service.GetAllStudentsAsync();
    }

    [HttpPost("")]
    public async Task CreateNewStudentAsync(StudentDto dto)
    {
        await service.CreateNewStudentAsync(dto);
    }
}