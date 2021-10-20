using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;

        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        public string Get()
        {
            return "PONG";
        }
    }
}