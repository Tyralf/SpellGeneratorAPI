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
        public int InstabilityModification { get; set; }
        public int Priority { get; set; }

        private readonly IAddOn _AddOn;

        public InstabilityModifierDecorator(IAddOn addOn)
        {
            _AddOn = addOn;
        }

        public virtual void Apply(Spell spell)
        {
            spell.TotalInstability += this.InstabilityModification;
        }
    }
}
