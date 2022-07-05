using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repository;
using NetAcademy.Repository.Interfaces;

namespace NetAcademy.Services;

public class StudentService
{
    private IStudentRepository repository;

    public StudentService(IStudentRepository repo)
    {
        repository = repo;
    }

    public async Task EnrollStudentToCourseAsync(long id, long courseId)
    {
        await repository.EnrollStudentToCourseAsync(id, courseId);
    }

    public async Task<StudentInfoDto> GetStudentInfoAsync(long id)
    {
        return await repository.GetStudentInfoAsync(id);
    }

    public async Task CreateNewStudentAsync(StudentDto dto)
    {
        await repository.CreateNewStudentAsync(dto);
    }

    public async Task UpdateStudentAsync(long id, StudentDto dto)
    {
        await repository.UpdateStudentAsync(id, dto);
    }

    public async Task<List<StudentDto>> GetAllStudentsAsync()
    {
        return await repository.GetAllStudentsAsync();
    }

    public async Task<StudentDto?> GetStudentAsync(long id)
    {
        return await repository.GetStudentAsync(id);
    }

    public async Task DeleteStudentAsync(long id)
    {
        await repository.DeleteStudentAsync(id);
    }

    public async Task CancelStudentFromCourseAsync(long id, long courseId)
    {
        await repository.CancelStudentFromCourseAsync(id, courseId);
    }
}