using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Controllers
{
    [ApiController]
    [Route("pimpis")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly Context _context;

        public WeatherForecastController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 50000).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("oras")]
        public async Task<IActionResult> GetOras()
        {
            return Ok("asd");
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var firstUser = _context.Users.Where(x => x.Username == "asd").ToList();
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPost("users/{id}")]
        public async Task<IActionResult> CreateUser(int id)
        {
            // var result = service.CreateUser(id);
            return Ok();
        }
    }
}