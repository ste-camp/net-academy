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
}