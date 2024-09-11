using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOnDecorators
{
    public class TargetModifierDecorator : InstabilityModifierDecorator
    {
        public string TargetModification { get; set; }
        public TargetModifierDecorator(IAddOn addOn) : base(addOn) { }

        public override void Apply(Spell spell)
        {
            spell.TotalInstability += this.InstabilityModification;
            spell.Target = this.TargetModification;
        }
    }
}
