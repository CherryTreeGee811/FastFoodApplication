using FastFoodAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class EmployeeController : ControllerBase
    {
        private readonly FastFoodDbContext _fastFoodDbContext;

        public EmployeeController(FastFoodDbContext fastFoodDbContext)
        {
            _fastFoodDbContext = fastFoodDbContext;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fastFoodDbContext.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.EmailAddress,
                    JobTitle = e.JobTitle.Title,
                    StationName = e.Station != null ? e.Station.StationName : null
                })
                .ToListAsync();

            return Ok(employees);
        }
    }
}
