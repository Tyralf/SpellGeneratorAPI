using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Business.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellGenerator.Business.BusinessModels.AddOns;

namespace SpellGenerator.Test.Converters.BusinessToData
{
    public class SpellBusinessToDataConverterTest
    {
        private readonly SpellConverter _spellConverter;
        private Spell businessSpell = new Spell
        {
            Name = "Fireball",
            Id = 1,
            ManaCost = 50,
            Description = "A powerful fire spell."
        };

        public SpellBusinessToDataConverterTest()
        {
            _spellConverter = new SpellConverter();
        }

        [Fact]
        public void TestConvertDataToBusiness_OutputType()
        {
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.IsType<Data.DataModels.Spell>(result);
        }

        [Fact]
        public void TestConvertDataToBusiness_BasicDataTransfer()
        {
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.Equal("Fireball", result.Name);
            Assert.Equal(1, result.Id);
            Assert.Equal(50, result.ManaCost);
            Assert.Equal("A powerful fire spell.", result.Description);
        }

        [Fact]
        public void TestConvertDataToBusiness_BasicAddOnConversion()
        {
            businessSpell.AddOns.Add(new BasicAddOn()
            {
                Id = -1,
                Name = "AddOn de Base pour les tests",
                Description = "AddOn pour les Test unitaires"
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            var basicBusinessAddOn = Assert.IsType<BasicAddOn>(businessSpell.AddOns.First());
            Assert.Equal(basicBusinessAddOn.Id, result.AddOns.First().Id);
            Assert.Equal(basicBusinessAddOn.Name, result.AddOns.First().Name);
            Assert.Equal( basicBusinessAddOn.Description, result.AddOns.First().Description);
            Assert.Equal(Data.DataModels.Enums.AddOnTypeEnum.Base, result.AddOns.First().Type);
        }

        [Fact]
        public void TestConvertDataToBusiness_InstabilityAddOnConversion()
        {
            businessSpell.AddOns.Add(new InstabilityModifierAddOn()
            {
                Id = -2,
                Name = "AddOn d'Instabilité pour les tests",
                Description = "AddOn pour les Test unitaires",
                InstabilityModificationValue = -2
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            var basicInstabilityAddOn = Assert.IsType<InstabilityModifierAddOn>(businessSpell.AddOns.First());
            Assert.Equal(basicInstabilityAddOn.Id, result.AddOns.First().Id);
            Assert.Equal(basicInstabilityAddOn.Name, result.AddOns.First().Name);
            Assert.Equal(basicInstabilityAddOn.Description, result.AddOns.First().Description);
            Assert.Equal(basicInstabilityAddOn.InstabilityModificationValue, result.AddOns.First().InstabilityValue);
            Assert.Equal(Data.DataModels.Enums.AddOnTypeEnum.InstabilityOnly, result.AddOns.First().Type);
        }

        [Fact]
        public void TestConvertDataToBusiness_RangeAddOnConversion()
        {
            businessSpell.AddOns.Add(new RangeModifierAddOn()
            {
                Id = -3,
                Name = "AddOn de range pour les tests",
                Description = "AddOn pour les Test unitaires",
                InstabilityModificationValue = -2,
                RangeModificationValue = "25m de distance"
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            var basicRangeAddOn = Assert.IsType<RangeModifierAddOn>(businessSpell.AddOns.First());
            Assert.Equal(basicRangeAddOn.Id, result.AddOns.First().Id);
            Assert.Equal(basicRangeAddOn.Name, result.AddOns.First().Name);
            Assert.Equal(basicRangeAddOn.Description, result.AddOns.First().Description);
            Assert.Equal(basicRangeAddOn.InstabilityModificationValue, result.AddOns.First().InstabilityValue);
            Assert.Equal(basicRangeAddOn.RangeModificationValue, result.AddOns.First().ModifierValue);
            Assert.Equal(Data.DataModels.Enums.AddOnTypeEnum.Range, result.AddOns.First().Type);
        }
        
        [Fact]
        public void TestConvertDataToBusiness_CastAddOnConversion()
        {
            businessSpell.AddOns.Add(new CastModifierAddOn()
            {
                Id = -3,
                Name = "AddOn de cast pour les tests",
                Description = "AddOn pour les Test unitaires",
                InstabilityModificationValue = -2,
                CastModificationValue = "4 PA"
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            var basicCastAddOn = Assert.IsType<CastModifierAddOn>(businessSpell.AddOns.First());
            Assert.Equal(basicCastAddOn.Id, result.AddOns.First().Id);
            Assert.Equal(basicCastAddOn.Name, result.AddOns.First().Name);
            Assert.Equal(basicCastAddOn.Description, result.AddOns.First().Description);
            Assert.Equal(basicCastAddOn.InstabilityModificationValue, result.AddOns.First().InstabilityValue);
            Assert.Equal(basicCastAddOn.CastModificationValue, result.AddOns.First().ModifierValue);
            Assert.Equal(Data.DataModels.Enums.AddOnTypeEnum.Cast, result.AddOns.First().Type);
        }

        [Fact]
        public void TestConvertDataToBusiness_TargetAddOnConversion()
        {
            businessSpell.AddOns.Add(new TargetModifierAddOn()
            {
                Id = -3,
                Name = "AddOn de target pour les tests",
                Description = "AddOn pour les Test unitaires",
                InstabilityModificationValue = -2,
                TargetModificationValue = "AOE 3m de rayon"
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            var basicCastAddOn = Assert.IsType<TargetModifierAddOn>(businessSpell.AddOns.First());
            Assert.Equal(basicCastAddOn.Id, result.AddOns.First().Id);
            Assert.Equal(basicCastAddOn.Name, result.AddOns.First().Name);
            Assert.Equal(basicCastAddOn.Description, result.AddOns.First().Description);
            Assert.Equal(basicCastAddOn.InstabilityModificationValue, result.AddOns.First().InstabilityValue);
            Assert.Equal(basicCastAddOn.TargetModificationValue, result.AddOns.First().ModifierValue);
            Assert.Equal(Data.DataModels.Enums.AddOnTypeEnum.Target, result.AddOns.First().Type);
        }

        [Fact]
        public void TestConvertDataToBusiness_DurationAddOnConversion()
        {
            businessSpell.AddOns.Add(new DurationModifierAddOn()
            {
                Id = -3,
                Name = "AddOn de durée pour les tests",
                Description = "AddOn pour les Test unitaires",
                InstabilityModificationValue = -2,
                DurationModificationValue = "Dure 4 tours"
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            var basicCastAddOn = Assert.IsType<DurationModifierAddOn>(businessSpell.AddOns.First());
            Assert.Equal(basicCastAddOn.Id, result.AddOns.First().Id);
            Assert.Equal(basicCastAddOn.Name, result.AddOns.First().Name);
            Assert.Equal(basicCastAddOn.Description, result.AddOns.First().Description);
            Assert.Equal(basicCastAddOn.InstabilityModificationValue, result.AddOns.First().InstabilityValue);
            Assert.Equal(basicCastAddOn.DurationModificationValue, result.AddOns.First().ModifierValue);
            Assert.Equal(Data.DataModels.Enums.AddOnTypeEnum.Duration, result.AddOns.First().Type);
        }

        [Fact]
        public void TestConvertBusinessToData_Masteries()
        {
            Mastery parentMastery = new Mastery()
            {
                Id = -5,
                Name = "Evocation"
            };
            Mastery invocationMastery = new Mastery()
            {
                Id = -6,
                Name = "Invocation",
                ParentMastery = parentMastery
            };

            businessSpell.RequieredMasteries.Add(new Mastery()
            {
                Id = -7,
                Name = "Advanced Invocation",
                ParentMastery = invocationMastery
            });

            businessSpell.RequieredMasteries.Add(new Mastery()
            {
                Id = -8,
                Name = "Elivocation",
                ParentMastery = parentMastery
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.Equal(4, result.RequieredMasteries.Count);
            Assert.Contains(result.RequieredMasteries, m => m.Id == -5 && m.Name == "Evocation");
            Assert.Contains(result.RequieredMasteries, m => m.Id == -6 && m.Name == "Invocation");
            Assert.Contains(result.RequieredMasteries, m => m.Id == -7 && m.Name == "Advanced Invocation");
            Assert.Contains(result.RequieredMasteries, m => m.Id == -8 && m.Name == "Elivocation");
        }

        [Fact]
        public void TestConvertBusinessToData_Magics()
        {
            businessSpell.RequieredMagics.Add(new Magic()
            {
                Id = -1,
                Name = "Magie Incendiaire"
            });

            businessSpell.RequieredMagics.Add(new Magic()
            {
                Id = -2,
                Name = "Magie Aerienne"
            });
            var result = _spellConverter.ConvertBusinessToData(businessSpell);

            Assert.Equal(2, result.RequieredMagics.Count);
            Assert.Contains(result.RequieredMagics, m => m.Id == -1 && m.Name == "Magie Incendiaire");
            Assert.Contains(result.RequieredMagics, m => m.Id == -2 && m.Name == "Magie Aerienne");
        }
    }
}
