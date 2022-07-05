using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories.Extensions
{
    internal static class SqlModelsExtensions
    {

        public static Course? ToSqlModel(this CourseDto x)
        {
            if (x == null) return null;
            return new Course()
            {
                CourseCategory = x.CourseCategory,
                CourseName = x.CourseName,
                CourseDate = x.CourseDate,
                TeacherId = x.TeacherId
            };
        }

        public static Teacher? ToSqlModel(this TeacherDto x)
        {
            if (x == null) return null;
            return new Teacher()
            {
                TeacherEmail = x.TeacherEmail,
                TeacherName = x.TeacherName,
                TeacherSurname = x.TeacherSurname,
            };
        }

        public static Student? ToSqlModel(this StudentDto x)
        {
            if (x == null) return null;
            return new Student()
            {
                StudentEmail = x.StudentEmail,
                StudentName = x.StudentName,
                StudentSurname = x.StudentSurname,
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

        public static StudentDto? ToDto(this Student x)
        {
            if (x == null) return null;
            return new StudentDto()
            {
                StudentId = x.Id,
                StudentEmail = x.StudentEmail,
                StudentName = x.StudentName,
                StudentSurname = x.StudentSurname,
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

        public static StudentCourseDto? ToDto(this StudentCourse x)
        {
            if (x == null) return null;
            return new StudentCourseDto()
            {
                StudentId = x.StudentId,
                CourseId = x.CourseId,
            };
        }
    }
}
