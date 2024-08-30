using Moq;
using SpellGenerator.Business.BusinessModels;
using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Business.Interfaces;
using SpellGenerator.Data.DataModels;
using System.Collections.Generic;
using Xunit;

namespace SpellGenerator.Test
{
    public class SpellDataToBusinessConverterTests
    {
        private readonly SpellConverter _spellConverter;
        private Data.DataModels.Spell dataSpell = new Data.DataModels.Spell
        {
            Name = "Fireball",
            Id = 1,
            ManaCost = 50,
            Description = "A powerful fire spell.",
            AddOns = new List<Data.DataModels.AddOn>() // Simuler des AddOns vides pour les test de base
        };
        public SpellDataToBusinessConverterTests()
        {
            _spellConverter = new SpellConverter();
        }

        [Fact]
        public void TestConvertDataToBusiness_OutputType()
        {
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.IsType<Business.BusinessModels.Spell>(result);
        }

        [Fact]
        public void TestConvertDataToBusiness_BasicDataTransfer()
        {
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.Equal("Fireball", result.Name);
            Assert.Equal(1, result.Id);
            Assert.Equal(50, result.ManaCost);
            Assert.Equal("A powerful fire spell.", result.Description);
        }

        [Fact]
        public void TestConvertDataToBusiness_InitialValuesAreAdded()
        {
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.numericalLevel == 0, $"Erreur: Le niveau numérique du sort n'est pas initialisé correctement. Attendu : 0 | Actuel : {result.numericalLevel}");
            Assert.True(result.Range != null, "Erreur: La portée du sort n'est pas initialisée correctement.");
            Assert.True(result.CastTime != null, "Erreur: Le temps d'incantation du sort n'est pas initialisé correctement.");
            Assert.True(result.Duration != null, "Erreur: La durée du sort n'est pas initialisée correctement.");
            Assert.True(result.Target != null, "Erreur: La cible du sort n'est pas initialisée correctement.");
            Assert.True(result.TotalInstability == 0, $"Erreur: L'instabilité totale du sort n'est pas initialisée correctement. Attendu : 0 | Actuel : {result.TotalInstability}");
        }


        [Fact]
        public void TestConvertDataToBusiness_BasicAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -1,
                Name = "AddOn de Base pour les tests",
                Description = "AddOn pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Base
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
        }

        [Fact]
        public void TestConvertDataToBusiness_InstabilityAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -2,
                Name = "AddOn de modifiant l'instabilité pour les tests",
                Description = "AddOn pour les Test unitaires, avec modification de l'Instabilité",
                InstabilityValue = -2,
                Type = Data.DataModels.Enums.AddOnTypeEnum.InstabilityOnly
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            
            Assert.True(result.TotalInstability == -2, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par l'AddOn. Attendu : -2 | Actuel : {result.TotalInstability}");
        }

        [Fact]
        public void TestConvertDataToBusiness_RangeAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -3,
                Name = "AddOn de Modification de Range pour les tests",
                Description = "AddOn pour les Test unitaires, avec modifiaction de range et de l'instabilité",
                InstabilityValue = -3,
                ModifierValue = "Peut toucher n'importe quelle cible dans le champ de vision",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Range
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            
            Assert.True(result.TotalInstability == -3, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par l'AddOn. Attendu : -3 | Actuel : {result.TotalInstability}");

            Assert.True(result.Range != null, $"Erreur: La valeur de range n'a pas été ajouté au sort");

            Assert.True(result.Range == dataSpell.AddOns.First().ModifierValue, $"Erreur: La valeur de modificateur n'a pas été correctement affecté a la range du sort. Attendu : {dataSpell.AddOns.First().ModifierValue} | Actuel : {result.Range}");
        }

    }
}
