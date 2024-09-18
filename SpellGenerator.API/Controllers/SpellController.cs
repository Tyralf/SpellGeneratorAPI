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
        /*[HttpGet("GetSpellTest")]
        public IActionResult GetSpellTest()
        {
            var result = _spellConverter.ConvertDataToBusiness(_spellRepository.FakeGetSpell());
            return Ok(result);
        }*/

        // Route: /Spell/GetZbaam
        [HttpGet("CreateFakeAddOn")]
        public void CreateFakeAddOns()
        {
            _spellRepository.CreateFakeAddOns();
        }

        // Route: /Spell/AddNumbers (HTTP POST)
        [HttpPost("AddNumbers")]
        public IActionResult AddNumbers([FromBody] AdditionRequest request)
        {
            if (request == null || request.Number1 == 0 || request.Number2 == 0)
            {
                return BadRequest("Les nombres ne doivent pas être null ou zéro.");
            }

            var result = request.Number1 + request.Number2;
            return Ok(new { Sum = result });
        }

        [HttpGet("Error500")]
        public IActionResult GenerateError500()
        {
            // Génère une exception volontairement pour tester le middleware
            throw new Exception("Ceci est une erreur de test de type server ! Normalement Code 500 !");
        }

        [HttpGet("Error404")]
        public IActionResult GenerateError()
        {
            // Génère une exception volontairement pour tester le middleware
            throw new KeyNotFoundException();
        }

        [HttpPost("CreateAddOn")]
        public void CreateAddOn([FromBody] AddOnCreationRequest request)
        {
            _spellRepository.CreateFakeAddOns();
        }
    }
}
