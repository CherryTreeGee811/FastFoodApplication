using Microsoft.AspNetCore.Mvc;


namespace ActionsEmissaryAPI.Controllers;


[ApiController]
[Route("/api")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    /// <summary>
    /// Used to verify that the application is running and can respond.
    /// </summary>
    /// <returns>Returns the status healthy.</returns>
    [HttpGet("/health")]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "healthy" });
    }
}
