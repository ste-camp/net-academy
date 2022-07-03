using Microsoft.AspNetCore.Mvc;
using NetAcademy.Services;

namespace NetAcademy.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController: ControllerBase
{
    private ILogger<ExampleController> logger;
    private ExampleService service;

    public ExampleController(ILogger<ExampleController> log, ExampleService s)
    {
        logger = log;
        service = s;
    }
    
    [HttpGet("")]//Address is /example
    [HttpGet("number")]//Address is also /example/number
    public int GetNumber()
    {
        return service.DoSomething();
    }
}