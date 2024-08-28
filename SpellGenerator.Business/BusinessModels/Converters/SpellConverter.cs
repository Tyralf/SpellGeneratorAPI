using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
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
            businessSpell.AddOns = new List<Business.Interfaces.IAddOn>();
            foreach(var dataAddOn in dataSpell.AddOns)
            {
                businessSpell.AddOns.Add(_addOnConverter.ConvertDataToBusiness(dataAddOn));
            }
            foreach(var buisnessAddOn in businessSpell.AddOns)
            {
                buisnessAddOn.Apply(businessSpell);
            }

            return businessSpell;
        }

        private Spell SetInitialValuesForBuisnessSpell(Spell businessSpell)
        {
            businessSpell.numericalLevel = 0;
            businessSpell.Range = "Soi-meme / Corps à Corps";
            businessSpell.CastTime = "2 PA";
            businessSpell.Duration = "1 tour";
            businessSpell.Target = "Une seule";
            businessSpell.TotalInstability = 0;
            


            return businessSpell;

        }
    }
}
