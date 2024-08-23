using Microsoft.AspNetCore.Mvc;
using SpellGenerator.API.Requests;

namespace SpellGeneratorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly ILogger<SpellController> _logger;

        public SpellController(ILogger<SpellController> logger)
        {
            _logger = logger;
        }

        // Route: /Spell/GetSpellTest
        [HttpGet("GetSpellTest")]
        public string GetSpellTest()
        {
            return "SpellTest";
        }

        // Route: /Spell/GetZbaam
        [HttpGet("GetZbaam")]
        public string GetZbaam()
        {
            return "Zbaam <3";
        }

        // Route: /Spell/AddNumbers (HTTP POST)
        [HttpPost("AddNumbers")]
        public IActionResult AddNumbers([FromBody] AdditionRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            var result = request.Number1 + request.Number2;
            return Ok(new { Sum = result });
        }
    }
}
