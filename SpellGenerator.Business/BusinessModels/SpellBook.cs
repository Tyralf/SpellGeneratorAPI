using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels
{
    public class SpellBook
    {
        public int Id { get; set; }
        public List<Spell> StoredSpells { get; set; } = new List<Spell>();
    }
}
