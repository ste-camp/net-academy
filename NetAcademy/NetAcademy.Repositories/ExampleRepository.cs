using Microsoft.Extensions.Logging;
using NetAcademy.Repositories;

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
        return 1;
    }
}