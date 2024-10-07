using Microsoft.AspNetCore.Mvc;
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Data.Repositories;
using SpellGeneratorAPI.Controllers;
using SpellGenerator.Business.Interfaces;

namespace SpellGenerator.API.Controllers
{
    public class AddOnController : ControllerBase
    {
        private readonly ILogger<AddOnController> _logger;
        private readonly AddOnRepository _addOnRepository;
        IConverter<SpellGenerator.Data.DataModels.AddOn, IAddOn> _addOnConverter;

        public AddOnController(ILogger<AddOnController> logger, AddOnRepository addOnRepository, AddOnConverter addOnConverter)
        {
            _logger = logger;
            _addOnRepository = addOnRepository;
            _addOnConverter = addOnConverter;
        }
    }
}
