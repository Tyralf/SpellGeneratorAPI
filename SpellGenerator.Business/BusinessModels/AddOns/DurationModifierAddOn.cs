using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOns
{
    public class DurationModifierAddOn : InstabilityModifierAddOn
    {
        public string DurationModificationValue { get; set; } = string.Empty;

        public override void Apply(Spell spell)
        {
            spell.Duration = DurationModificationValue;
            spell.TotalInstability += this.InstabilityModificationValue;
        }
    }
}
