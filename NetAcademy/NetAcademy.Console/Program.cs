using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetAcademy.Domain;
using NetAcademy.Repositories;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        var collection = new ServiceCollection();

        collection
            .AddLogging()
            .AddDbContext<SchoolContext>(options =>
                options.UseSqlServer("Server=(localdb)\\\\MSSQLLocalDB;Database=NetAcademy;Trusted_Connection=True;"));


        var service = collection.BuildServiceProvider();

        //string json = JsonSerializer.Serialize(res, new JsonSerializerOptions() { WriteIndented = true });
        //Console.WriteLine(json);

    }
}