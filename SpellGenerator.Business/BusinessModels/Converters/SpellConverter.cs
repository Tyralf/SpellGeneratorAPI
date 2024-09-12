using Microsoft.Extensions.Options;
using SpellGenerator.Business.BusinessModels.AddOns;
using SpellGenerator.Business.BusinessModels.Converters.Helpers;
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.Converters
{
    public class SpellConverter : IConverter<Data.DataModels.Spell, Spell>
    {
        AddOnConverter _addOnConverter = new AddOnConverter();
        public Data.DataModels.Spell ConvertBusinessToData(Spell buisnessModel)
        {
            throw new NotImplementedException();
        }

        public Spell ConvertDataToBusiness(Data.DataModels.Spell dataSpell)
        {
            Spell businessSpell = new Spell();
            businessSpell = SetInitialValuesForBuisnessSpell(businessSpell);
            businessSpell.Name = dataSpell.Name;
            businessSpell.Id = dataSpell.Id;
            businessSpell.ManaCost = dataSpell.ManaCost;
            businessSpell.Description = dataSpell.Description;
            businessSpell.AddOns = new List<IAddOn>();
            if(dataSpell.AddOns != null)
            {
                foreach (var dataAddOn in dataSpell.AddOns)
                {
                    businessSpell.AddOns.Add(_addOnConverter.ConvertDataToBusiness(dataAddOn));
                }
            }
            foreach(var buisnessAddOn in businessSpell.AddOns)
            {
                buisnessAddOn.Apply(businessSpell);
            }

            return businessSpell;
        }

        private Spell SetInitialValuesForBuisnessSpell(Spell businessSpell)
        {
            businessSpell.numericalLevel = SpellDefaults.DefaultNumericalLevel;
            businessSpell.Range = SpellDefaults.DefaultRange;
            businessSpell.CastTime = SpellDefaults.DefaultCastTime;
            businessSpell.Duration = SpellDefaults.DefaultDuration;
            businessSpell.Target = SpellDefaults.DefaultTarget;
            businessSpell.TotalInstability = SpellDefaults.DefaultTotalInstability;

            return businessSpell;

        }
    }
}
