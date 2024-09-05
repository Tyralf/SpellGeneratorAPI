using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOnDecorators
{
    internal class DurationModifierDecorator : InstabilityModifierDecorator
    {
        public string DurationModification { get; set; }
        public DurationModifierDecorator(IAddOn addOn) : base(addOn) { }

        public override void Apply(Spell spell)
        {
            spell.TotalInstability += this.InstabilityModification;
            spell.Duration = this.DurationModification;
        }
    }
}
