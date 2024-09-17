using SpellGenerator.Data.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public UserRoleEnum Role { get; set; }
        public SpellBook SpellBook { get; set; } = new SpellBook();
        public List<Magic> KnownMagics { get; set; } = new List<Magic>();
        public List<Mastery> KnownMasteries { get; set; } = new List<Mastery>();
    }
}
