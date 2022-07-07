using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repositories.Interfaces;

public interface ITeachersRepository
{
    public Task CreateNewTeacherAsync(TeacherDto dto);
    public Task DeleteTeacherAsync(long id);
    public Task UpdateTeacherAsync(long id, TeacherDto dto);
    public Task<TeacherDto> GetTeacherAsync(long id);
    public List<TeacherDto> GetAllTeachers();
    public List<TeacherInfoDto> GetTeachersAndCourses();
}