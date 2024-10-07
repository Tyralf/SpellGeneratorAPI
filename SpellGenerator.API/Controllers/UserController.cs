using Microsoft.AspNetCore.Mvc;
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Business.Interfaces;
using SpellGenerator.Data.Repositories;
using SpellGenerator.Business.BusinessModels;

namespace SpellGenerator.API.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserRepository _userRepository;
        IConverter<SpellGenerator.Data.DataModels.User, User> _userConverter;

        public UserController(ILogger<UserController> logger, UserRepository userRepository, UserConverter userConverter)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userConverter = userConverter;
        }
    }
}
