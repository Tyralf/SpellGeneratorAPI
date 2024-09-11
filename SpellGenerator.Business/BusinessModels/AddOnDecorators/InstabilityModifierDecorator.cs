using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOnDecorators
{
    public class InstabilityModifierDecorator : IAddOn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InstabilityModification { get; set; }
        public int Priority { get; set; }
        public bool isCumulative { get; set; }

        private readonly IAddOn _AddOn;

        public InstabilityModifierDecorator(IAddOn addOn)
        {
            _AddOn = addOn;
            Id = addOn.Id;
            Name = addOn.Name;
            Description = addOn.Description;
        }

        public virtual void Apply(Spell spell)
        {
            spell.TotalInstability += this.InstabilityModification;
        }
    }
}
