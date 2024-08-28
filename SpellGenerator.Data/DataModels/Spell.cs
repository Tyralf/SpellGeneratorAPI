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
        public string Name { get; set; }
        public int ManaCost { get; set; }
        public string Description { get; set; }
        public List<Magic> RequieredMagics { get; set; }
        public List<Mastery> RequieredMasteries { get; set; }
        public List<AddOn> AddOns { get; set; }
    }
}
