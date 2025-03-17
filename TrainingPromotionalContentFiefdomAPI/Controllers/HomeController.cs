using Microsoft.AspNetCore.Mvc;


namespace TrainingAndPromotionFiefdomAPI.Controllers;

[ApiController]
[Route("/api")]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("/health")]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "healthy" });
    }
}
