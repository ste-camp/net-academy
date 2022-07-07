using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.Interfaces;
using NetAcademy.Repository;

namespace NetAcademy.Services;

public class TeachersService
{
    private ITeachersRepository repository;
    
    public TeachersService(ITeachersRepository repo)
    {
        repository = repo;
    }

    public async Task CreateNewTeacherAsync(TeacherDto dto)
    {
        await repository.CreateNewTeacherAsync(dto);
    }

    public async Task UpdateTeacherAsync(long id, TeacherDto dto)
    {
        await repository.UpdateTeacherAsync(id, dto);
    }

    public async Task DeleteTeacherAsync(long id)
    {
        await repository.DeleteTeacherAsync(id);
    }

    public List<TeacherDto> GetAllTeachers()
    {
        return repository.GetAllTeachers();
    }

    public async Task<TeacherDto?> GetTeacherAsync(long id)
    {
        return await repository.GetTeacherAsync(id);
    }
}