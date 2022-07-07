using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetAcademy.Domain.Models.DTOs;
using NetAcademy.Repositories;
using NetAcademy.Repositories.Implementations;
using NetAcademy.Repositories.Interfaces;
using NetAcademy.Repository;
using NetAcademy.Services;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var collection = new ServiceCollection();

        collection
            .AddLogging()
            .AddDbContext<SchoolContext>(options =>
                options.UseSqlServer("Server=(localdb)\\\\MSSQLLocalDB;Database=NetAcademy;Trusted_Connection=True;"))
            .AddScoped<IExampleRepository, ExampleRepository>()
            .AddScoped<ITeachersRepository, TeachersRepository>()
            .AddScoped<ExampleService>()
            .AddScoped<TeachersService>();


        var service = collection.BuildServiceProvider();
        var _service = service.GetRequiredService<TeachersService>();

        TeacherDto dto = new() { TeacherName = "Marcello", TeacherSurname = "Rossi", TeacherEmail = "mar.rossi@email.com" };

        //await _service.CreateNewTeacherAsync(dto);
        var res = _service.GetAllTeachers();
        string json = JsonSerializer.Serialize(res, new JsonSerializerOptions() { WriteIndented = true });
        Console.WriteLine(json);

    }
}