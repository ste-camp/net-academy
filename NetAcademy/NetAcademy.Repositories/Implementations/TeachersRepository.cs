using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.Extensions;
using NetAcademy.Repositories.Interfaces;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repositories.Implementations;

public class TeachersRepository : ITeachersRepository
{
    private ILogger<TeachersRepository> logger;
    private SchoolContext context;

    public TeachersRepository(ILogger<TeachersRepository> l, SchoolContext c)
    {
        logger = l;
        context = c;
    }

    public async Task CreateNewTeacherAsync(TeacherDto dto)
    {
        //// unsecure query
        //var sql = $"insert into Teacher(TeacherName, TeacherSurname, TeacherEmail) values('{dto.TeacherName}', '{dto.TeacherSurname}', '{dto.TeacherEmail}');";

        //using (var connection = new SqlConnection(Constants.DAPPER_CONNECTION))
        //{
        //    var result = await connection.QueryAsync(sql);
        //}

        //// parameterized operation
        //var parameters = new
        //{
        //    TeacherName = dto.TeacherName,
        //    TeacherSurname = dto.TeacherSurname,
        //    TeacherEmail = dto.TeacherEmail
        //};

        //var sql = $"insert into Teacher(TeacherName, TeacherSurname, TeacherEmail) values(@TeacherName, @TeacherSurname, @TeacherEmail);";

        //using (var connection = new SqlConnection(Constants.DAPPER_CONNECTION))
        //{
        //    var result = await connection.QueryAsync(sql, parameters);
        //}

        await context.Teachers.AddAsync(dto.ToSqlModel());
        await context.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(long id)
    {
        Teacher teacher = await context.Teachers.FindAsync(id);
        context.Teachers.Remove(teacher);
        await context.SaveChangesAsync();
    }

    public List<TeacherDto> GetAllTeachers()
    {
        return context.Teachers.Select(x => x.ToDto()).ToList();
    }

    public async Task<TeacherDto> GetTeacherAsync(long id)
    {
        Teacher teacher = await context.Teachers.FindAsync(id);
        return teacher.ToDto();
    }

    public async Task UpdateTeacherAsync(long id, TeacherDto dto)
    {
        Teacher teacher = await context.Teachers.FindAsync(id);
        if (teacher != null)
        {
            teacher.TeacherName = dto.TeacherName;
            teacher.TeacherSurname = dto.TeacherSurname;
            teacher.TeacherEmail = dto.TeacherEmail;

            await context.SaveChangesAsync();
        }
    }

}
