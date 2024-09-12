using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.AddOns
{
    public class InstabilityModifierAddOn : BasicAddOn
    {
        public int InstabilityModificationValue { get; set; }

        public override void Apply(Spell spell) 
        {
            spell.TotalInstability += this.InstabilityModificationValue;
        }
    }
}
