using NetAcademy.Repository;

namespace NetAcademy.Services;

public class ExampleService
{
    private IExampleRepository repository;
    
    public ExampleService(IExampleRepository repo)
    {
        repository = repo;
    }

    /// <summary>
    /// Some simple business logic
    /// </summary>
    /// <returns></returns>
    public int DoSomething()
    {
        return repository.GetSomething();          
    }
}