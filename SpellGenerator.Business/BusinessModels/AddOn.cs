using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellGenerator.Business.Interfaces;

namespace SpellGenerator.Business.BusinessModels
{
    public class AddOn : IAddOn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Apply(Spell spell) { }
    }
}
