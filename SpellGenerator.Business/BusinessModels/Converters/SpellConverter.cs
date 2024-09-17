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
        MasteryConverter _masteryConverter = new MasteryConverter();
        MagicConverter _magicConverter = new MagicConverter();
        public Data.DataModels.Spell ConvertBusinessToData(Spell buisnessSpell)
        {
            Data.DataModels.Spell dataSpell = new Data.DataModels.Spell();
            dataSpell.Id = buisnessSpell.Id;
            dataSpell.Name = buisnessSpell.Name;
            dataSpell.ManaCost = buisnessSpell.ManaCost;
            dataSpell.Description = buisnessSpell.Description;
            foreach (var magic in buisnessSpell.RequieredMagics)
            {
                dataSpell.RequieredMagics.Add(_magicConverter.ConvertBusinessToData(magic));
            }
            foreach (var mastery in buisnessSpell.RequieredMasteries)
            {
                AddMasteryAndParentsBuisnessToData(dataSpell, _masteryConverter.ConvertBusinessToData(mastery));
            }
            foreach (var buisnessAddOn in buisnessSpell.AddOns)
            {
                dataSpell.AddOns.Add(_addOnConverter.ConvertBusinessToData(buisnessAddOn));
            }
            return dataSpell;
        }

        public Spell ConvertDataToBusiness(Data.DataModels.Spell dataSpell)
        {
            Spell businessSpell = new Spell();
            businessSpell = SetInitialValuesForBuisnessSpell(businessSpell);
            businessSpell.Name = dataSpell.Name;
            businessSpell.Id = dataSpell.Id;
            businessSpell.ManaCost = dataSpell.ManaCost;
            businessSpell.Description = dataSpell.Description;
            foreach (var magic in dataSpell.RequieredMagics)
            {
                businessSpell.RequieredMagics.Add(_magicConverter.ConvertDataToBusiness(magic));
            }
            foreach (var mastery in dataSpell.RequieredMasteries)
            {
                AddMasteryAndParentsDataToBuisness(businessSpell, _masteryConverter.ConvertDataToBusiness(mastery));
            }
            foreach (var dataAddOn in dataSpell.AddOns)
            {
                businessSpell.AddOns.Add(_addOnConverter.ConvertDataToBusiness(dataAddOn));
            }
            foreach (var buisnessAddOn in businessSpell.AddOns)
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

        private void AddMasteryAndParentsDataToBuisness(Spell businessSpell, Mastery mastery)
        {
            if (!businessSpell.RequieredMasteries.Any(m => m.Id == mastery.Id))
            {
                businessSpell.RequieredMasteries.Add(mastery);
                if (mastery.ParentMastery != null)
                {
                    AddMasteryAndParentsDataToBuisness(businessSpell, mastery.ParentMastery);
                }
            }
        }

        private void AddMasteryAndParentsBuisnessToData(Data.DataModels.Spell dataSpell, Data.DataModels.Mastery mastery)
        {
            if (!dataSpell.RequieredMasteries.Any(m => m.Id == mastery.Id))
            {
                dataSpell.RequieredMasteries.Add(mastery);
                if (mastery.ParentMastery != null)
                {
                    AddMasteryAndParentsBuisnessToData(dataSpell, mastery.ParentMastery);
                }
            }
        }

    }
}
