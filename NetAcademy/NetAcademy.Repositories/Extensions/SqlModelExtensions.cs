using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories.Extensions;

internal static class SqlModelExtensions
{
    public static StudentDto? ToDto(this Student x)
    {
        if (x == null) return null;
        return new StudentDto()
        {
            StudentId = x.Id,
            StudentEmail = x.StudentEmail,
            StudentName = x.StudentName,
            StudentSurname = x.StudentSurname
        };
    }

    public static CourseDto? ToDto(this Course x)
    {
        if (x == null) return null;
        return new CourseDto()
        {
            CourseId = x.Id,
            CourseCategory = x.CourseCategory,
            CourseName = x.CourseName,
            CourseDate = x.CourseDate,
            TeacherId = x.TeacherId
        };
    }

    public static TeacherDto? ToDto(this Teacher x)
    {
        if (x == null) return null;
        return new TeacherDto()
        {
            TeacherId = x.Id,
            TeacherEmail = x.TeacherEmail,
            TeacherName = x.TeacherName,
            TeacherSurname = x.TeacherSurname,
        };
    }

    public static Teacher? ToSqlModel(this TeacherDto x)
    {
        if (x == null) return null;
        return new Teacher()
        {
            Id = x.TeacherId,
            TeacherEmail = x.TeacherEmail,
            TeacherName = x.TeacherName,
            TeacherSurname = x.TeacherSurname,
        };
    }

    public static StudentCourseDto? ToDto(this StudentCourse x)
    {
        if (x == null) return null;
        return new StudentCourseDto()
        {
            StudentId = x.StudentId,
            CourseId = x.CourseId,
            Course = x.Course.ToDto()
        };
    }


}
