using Microsoft.AspNetCore.Mvc;
using WebApplicationforsemgrep.Helpers;

namespace WebApplicationforsemgrep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get(string input)
        {
            SqlClient sqlClient = new SqlClient();
            var res = sqlClient.Union(input);

            return Ok(res);
        }
    }
}
