using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class SpellBook
    {
        [Key]
        public int Id { get; set; }
        public List<Spell> StoredSpells { get; set; } = new List<Spell>();
        public User User { get; set; } = new User();
    }
}
