using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain;
using NetAcademy.Repositories;
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
            .AddScoped<ExampleService>();


        var service = collection.BuildServiceProvider();
        var _service = service.GetRequiredService<ExampleService>();
        _service.DoSomething();
        //string json = JsonSerializer.Serialize(res, new JsonSerializerOptions() { WriteIndented = true });
        //Console.WriteLine(json);

    }
}