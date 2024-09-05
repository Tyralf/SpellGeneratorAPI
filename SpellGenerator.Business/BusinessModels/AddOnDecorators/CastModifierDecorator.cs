using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOnDecorators
{
    internal class CastModifierDecorator : InstabilityModifierDecorator
    {
        public string CastModification { get; set; }
        public CastModifierDecorator(IAddOn addOn) : base(addOn) { }

        public override void Apply(Spell spell)
        {
            spell.TotalInstability += this.InstabilityModification;
            spell.CastTime = this.CastModification;
        }
    }
}
