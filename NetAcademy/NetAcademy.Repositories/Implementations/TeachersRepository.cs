using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories.Interfaces;

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
        // unsecure query
        var sql = $"insert into Teacher(TeacherName, TeacherSurname, TeacherEmail) values('{dto.TeacherName}', '{dto.TeacherSurname}', '{dto.TeacherEmail}');";

        using (var connection = new SqlConnection(Constants.DAPPER_CONNECTION))
        {
            var result = await connection.QueryAsync(sql);
        }
    }
}
