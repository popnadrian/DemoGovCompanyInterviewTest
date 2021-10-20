using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tests
{
    [ApiController, Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "PONG";
        }
    }
}