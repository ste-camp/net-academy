using NetAcademy.Domain.Models.DTOs;

namespace NetAcademy.Repositories.Interfaces;

public interface IStudentsRepository
{
    public Task EnrollStudentToCourseAsync(long id, long courseId);
    public Task CancelStudentFromCourseAsync(long id, long courseId);
    public Task CreateNewStudentAsync(StudentDto dto);
    public Task DeleteStudentAsync(long id);
    public Task UpdateStudentAsync(long id, StudentDto dto);
    public Task<StudentDto> GetStudentAsync(long id);
    public Task<List<StudentDto>> GetAllStudentsAsync();


    public Task<StudentInfoDto> GetStudentCourseAsync(long id);
    public Task<StudentInfoDto> GetStudentCoursesAndTeachersAsync(long id);
}