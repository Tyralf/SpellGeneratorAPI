using SpellGenerator.Business.BusinessModels.AddOns;
using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public int numericalLevel { get; set; }
        public int TotalInstability { get; set; }
        public int ManaCost { get; set; }
        public string Range { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public string CastTime { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Magic> RequieredMagics { get; set; } = new List<Magic>();
        public List<Mastery> RequieredMasteries { get; set; } = new List<Mastery>();
        public List<IAddOn> AddOns { get; set; } = new List<IAddOn>();
    }
}
