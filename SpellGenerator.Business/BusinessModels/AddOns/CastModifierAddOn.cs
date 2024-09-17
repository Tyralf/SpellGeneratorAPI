using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOns
{
    public class CastModifierAddOn : InstabilityModifierAddOn
    {
        public string CastModificationValue { get; set; } = string.Empty;

        public override void Apply(Spell spell)
        {
            spell.CastTime = CastModificationValue;
            spell.TotalInstability += this.InstabilityModificationValue;
        }
    }
}
