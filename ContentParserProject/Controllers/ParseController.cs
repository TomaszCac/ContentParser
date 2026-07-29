using System.Net.Mime;
using System.Text.Json;
using ContentParserProject.Interfaces;
using ContentParserProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContentParserProject.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ParseController : ControllerBase
    {
        private readonly IContentParser _contentParser;

        public ParseController(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("parse-content")]
        public IActionResult Post([FromBody] ParseRequest request)
        {
            string decodedString = "";
            try
            {
                //Decode request data
                byte[] data = Convert.FromBase64String(request.Content);
                decodedString = System.Text.Encoding.UTF8.GetString(data);
                ParseResponse response;
                switch (request.Type)
                {
                    case ParsingContentType.INTERNAL_JSON:
                        response = _contentParser.HandleJson(decodedString);
                        break;
                    case ParsingContentType.CSV:
                        response = _contentParser.HandleCSV(decodedString);
                        break;
                    default:
                        //Throw exception if other type of type enum just in case
                        throw new ArgumentOutOfRangeException(
                            null,
                            "Request type is not supported"
                        );
                }
                return Ok(response);
            }
            //Catch all exceptions and send message about it in response
            catch (Exception ex)
            {
                JsonElement errorJson = JsonSerializer.SerializeToElement(
                    new
                    {
                        exception = ex.GetType().Name,
                        message = ex.Message,
                        userDecodedData = decodedString,
                    }
                );
                return BadRequest(new ParseResponse(Status.Failed, 0, errorJson));
            }
        }
    }
}
