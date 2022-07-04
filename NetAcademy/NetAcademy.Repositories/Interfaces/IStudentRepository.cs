using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repository.Interfaces;

public interface IStudentRepository
{
    public Task EnrollStudentToCourseAsync(long id, long courseId);
    public Task CancelStudentFromCourseAsync(long id);
    public Task<StudentInfoDto> GetStudentInfoAsync(long id);

    public Task CreateNewStudentAsync(StudentDto dto);
    public Task DeleteStudentAsync(long id);
    public Task UpdateStudentAsync(long id, StudentDto dto);
    public Task<StudentDto> GetStudentAsync(long id);
    public Task<List<StudentDto>> GetAllStudentsAsync();
}