using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOnDecorators
{
    public class RangeModifierDecorator : InstabilityModifierDecorator
    {
        public string RangeModification { get; set; }
        public RangeModifierDecorator(IAddOn addOn) : base(addOn) { }

        public override void Apply(Spell spell)
        {
            spell.TotalInstability += this.InstabilityModification;
            spell.Range = this.RangeModification;
        }
    }
}
