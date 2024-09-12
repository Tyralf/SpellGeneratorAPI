using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOns
{
    public class TargetModifierAddOn : InstabilityModifierAddOn
    {
        public string TargetModificationValue { get; set; } = string.Empty;

        public override void Apply(Spell spell)
        {
            spell.Target = TargetModificationValue;
            spell.TotalInstability += this.InstabilityModificationValue;
        }
    }
}
