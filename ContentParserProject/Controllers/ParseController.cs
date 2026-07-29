using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentParserProject.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ParseController : ControllerBase
    {
        [HttpPost("parse-content")]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
