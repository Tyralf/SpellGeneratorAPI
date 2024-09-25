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

        // Route: /Spell/GetZbaam
        [HttpGet("CreateFakeAddOn")]
        public void CreateFakeAddOns()
        {
            _spellRepository.CreateFakeAddOns();
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
    }
}
