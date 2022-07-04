using Microsoft.Extensions.Logging;
using NetAcademy.Repositories;
using NetAcademy.Repositories.SqlModels;

namespace NetAcademy.Repository;

public class ExampleRepository: IExampleRepository
{
    private ILogger<ExampleRepository> logger;
    private NetAcademyContext context;

    public ExampleRepository(ILogger<ExampleRepository> l, NetAcademyContext c)
    {
        logger = l;
        context = c;
    }
    
    public int GetSomething()
    {
        context.Students.Add(new Student() {StudentId = "ABC", FirstName = "Giuseppe", LastName = "Campanella" });
        context.SaveChanges();

        return 1;
    }
}