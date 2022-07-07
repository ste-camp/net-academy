using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repositories.Interfaces;

public interface ITeachersRepository
{
    public Task CreateNewTeacherAsync(TeacherDto dto);

}
