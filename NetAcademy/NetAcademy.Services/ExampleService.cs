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
        int value = repository.GetSomething();
        if (value == 1)
        {
            return value + 2;
        }
        else
        {
            return value + 10;
        }
    }
}