using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpellGenerator.API.DTOs.MapperProfiles;
using SpellGenerator.API.Requests;
using SpellGenerator.Business.BusinessModels;
using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using SpellGenerator.Data.Repositories;
using SpellGeneratorAPI.Controllers;

namespace SpellGenerator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MagicController : ControllerBase
    {
        private readonly ILogger<MagicController> _logger;
        private readonly MagicRepository _magicRepository;
        private readonly IMapper _magicMapper;
        private readonly IConverter<SpellGenerator.Data.DataModels.Magic, Magic> _magicConverter;

        public MagicController(ILogger<MagicController> logger, MagicRepository magicRepository, IMapper magicMapper, MagicConverter magicConverter)
        {
            _logger = logger;
            _magicRepository = magicRepository;
            _magicMapper = magicMapper;
            _magicConverter = magicConverter;
        }

        [HttpPost("AddMagic")]
        public IActionResult AddMagic([FromBody] MagicCreationDTO request)
        {
            _magicRepository.AddMagic(_magicConverter.ConvertBusinessToData(_magicMapper.Map<Magic>(request)));
            return Ok("La magie a bien été ajouté");
        }
    }
}
