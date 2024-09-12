using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ManaCost { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Magic> RequieredMagics { get; set; } = new List<Magic>();
        public List<Mastery> RequieredMasteries { get; set; } = new List<Mastery>();
        public List<AddOn> AddOns { get; set; } = new List<AddOn>();
    }
}
