using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOns
{
    public class RangeModifierAddOn : InstabilityModifierAddOn
    {
        public string RangeModificationValue { get; set; } = string.Empty;

        public override void Apply(Spell spell)
        {
            spell.Range = RangeModificationValue;
            spell.TotalInstability += this.InstabilityModificationValue;
        }
    }
}
