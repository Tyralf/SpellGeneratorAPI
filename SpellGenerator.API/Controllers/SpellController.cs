using Microsoft.AspNetCore.Mvc;
using SpellGenerator.API.Requests;
using SpellGenerator.Business.BusinessModels;
using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using SpellGenerator.Data.Repositories;

namespace SpellGeneratorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellController : ControllerBase
    {
        private readonly ILogger<SpellController> _logger;
        private readonly SpellRepository _spellRepository;
        IConverter<SpellGenerator.Data.DataModels.Spell, Spell> _spellConverter;

        public SpellController(ILogger<SpellController> logger, SpellRepository spellRepository, SpellConverter spellConverter)
        {
            _logger = logger;
            _spellRepository = spellRepository;
            _spellConverter = spellConverter;
        }

        // Route: /Spell/GetSpellTest
        [HttpGet("GetSpellTest")]
        public IActionResult GetSpellTest()
        {
            var result = _spellConverter.ConvertDataToBusiness(_spellRepository.FakeGetSpell());
            return Ok(result);
        }

        // Route: /Spell/GetZbaam
        [HttpGet("GetZbaam")]
        public string GetZbaam()
        {
            return "Zbaam <3 on git now, branch dev";
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
