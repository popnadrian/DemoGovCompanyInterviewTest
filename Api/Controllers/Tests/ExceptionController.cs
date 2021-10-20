using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tests
{
    [ApiController, Route("[controller]")]
    public class ExceptionController : ControllerBase
    {
        [HttpGet]
        public string Exception()
        {
            throw new Exception("user should never see this");
        }
    }
}