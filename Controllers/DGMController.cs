using Microsoft.AspNetCore.Mvc;

namespace FirstwebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DGMController : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Hello DGM!";
        }
    }
}