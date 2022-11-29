using Microsoft.EntityFrameworkCore;
using NetAcademy.Domain;
using NetAcademy.Repositories;
using NetAcademy.Repository.Implementations;
using NetAcademy.Repository.Interfaces;
using NetAcademy.Services;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddDbContext<SchoolContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.DB_CONNECTION_KEY)));

    builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
    builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
    builder.Services.AddScoped<ITeachersRepository, TeachersRepository>();

    builder.Services.AddScoped<StudentsService>();
    builder.Services.AddScoped<CoursesService>();
    builder.Services.AddScoped<TeachersService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseCors(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}