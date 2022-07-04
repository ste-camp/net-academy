using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repository.Interfaces;

public interface ITeacherRepository
{
    public Task CreateNewTeacherAsync(TeacherDto dto);
    public Task DeleteTeacherAsync(long id);
    public Task UpdateTeacherAsync(long id, TeacherDto dto);
    public Task<TeacherDto> GetTeacherAsync(long id);
    public List<TeacherDto> GetAllTeachers();
}