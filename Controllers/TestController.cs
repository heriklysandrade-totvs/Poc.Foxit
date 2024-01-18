using Microsoft.AspNetCore.Mvc;
using Poc.Foxit.Api.Responses;

namespace Poc.Foxit.Api.Controllers
{
    [Route("v1/test")]
    [ApiController]
    [ApiVersion("1.0")]
    public class TestController : ControllerBase
    {
        public TestController()
        {
            Console.WriteLine("**LOCAL CONSOLE** Initializing Test Controller");
        }

        [HttpGet("hello-world")]
        public IActionResult HelloWorld()
        {
            return Ok(new OkResponse("Hello world"));
        }
    }
}
