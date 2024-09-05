using Moq;
using SpellGenerator.Business.BusinessModels;
using SpellGenerator.Business.BusinessModels.Converters;
using SpellGenerator.Business.BusinessModels.Converters.Helpers;
using SpellGenerator.Business.Interfaces;
using SpellGenerator.Data.DataModels;
using System.Collections.Generic;
using Xunit;

namespace SpellGenerator.Test.Converters
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
            Assert.True(result.numericalLevel == SpellDefaults.DefaultNumericalLevel, $"Erreur: Le niveau numérique attendu est {SpellDefaults.DefaultNumericalLevel}, mais obtenu {result.numericalLevel}.");
            Assert.True(result.Range == SpellDefaults.DefaultRange, $"Erreur: La portée attendue est {SpellDefaults.DefaultRange}, mais obtenue {result.Range}.");
            Assert.True(result.CastTime == SpellDefaults.DefaultCastTime, $"Erreur: Le temps d'incantation attendu est {SpellDefaults.DefaultCastTime}, mais obtenu {result.CastTime}.");
            Assert.True(result.Duration == SpellDefaults.DefaultDuration, $"Erreur: La durée attendue est {SpellDefaults.DefaultDuration}, mais obtenue {result.Duration}.");
            Assert.True(result.Target == SpellDefaults.DefaultTarget, $"Erreur: La cible attendue est {SpellDefaults.DefaultTarget}, mais obtenue {result.Target}.");
            Assert.True(result.TotalInstability == SpellDefaults.DefaultTotalInstability, $"Erreur: L'instabilité totale attendue est {SpellDefaults.DefaultTotalInstability}, mais obtenue {result.TotalInstability}.");
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
                Description = "AddOn pour les Test unitaires, avec modification de range et de l'instabilité",
                InstabilityValue = -3,
                ModifierValue = "Peut toucher n'importe quelle cible dans le champ de vision",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Range
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");            
            Assert.True(result.TotalInstability == -3, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par l'AddOn. Attendu : -3 | Actuel : {result.TotalInstability}");
            Assert.True(result.Range == dataSpell.AddOns.First().ModifierValue, $"Erreur: La valeur de modificateur n'a pas été correctement affecté a la range du sort. Attendu : {dataSpell.AddOns.First().ModifierValue} | Actuel : {result.Range}");
        }

        [Fact]
        public void TestConvertDataToBusiness_CastAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -4,
                Name = "AddOn de Modification de temps de cast pour les tests",
                Description = "AddOn pour les Test unitaires, avec modification du temps de cast et de l'instabilité",
                InstabilityValue = 4,
                ModifierValue = "6 PA",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Cast
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            Assert.True(result.TotalInstability == 4, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par l'AddOn. Attendu : 4 | Actuel : {result.TotalInstability}");
            Assert.True(result.CastTime == dataSpell.AddOns.First().ModifierValue, $"Erreur: La valeur de modificateur n'a pas été correctement affecté au temps de cast du sort. Attendu : {dataSpell.AddOns.First().ModifierValue} | Actuel : {result.CastTime}");
        }

        [Fact]
        public void TestConvertDataToBusiness_TargetAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -5,
                Name = "AddOn de Modification de cibles pour les tests",
                Description = "AddOn pour les Test unitaires, avec modification des cibles possibles et de l'instabilité",
                InstabilityValue = -2,
                ModifierValue = "Peut toucher toutes les cibles dans une zone de 4m sur 6m",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Target
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            Assert.True(result.TotalInstability == -2, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par l'AddOn. Attendu : -2 | Actuel : {result.TotalInstability}");
            Assert.True(result.Target == dataSpell.AddOns.First().ModifierValue, $"Erreur: La valeur de modificateur n'a pas été correctement affecté au nombre de cibles du sort. Attendu : {dataSpell.AddOns.First().ModifierValue} | Actuel : {result.Target}");
        }

        [Fact]
        public void TestConvertDataToBusiness_DurationAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -6,
                Name = "AddOn de Modification de durée pour les tests",
                Description = "AddOn pour les Test unitaires, avec modifiaction de durée et de l'instabilité",
                InstabilityValue = -7,
                ModifierValue = "Le sort dure 1d4 tours",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Duration
            });
            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            Assert.True(result.TotalInstability == -7, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par l'AddOn. Attendu : -7 | Actuel : {result.TotalInstability}");
            Assert.True(result.Duration == dataSpell.AddOns.First().ModifierValue, $"Erreur: La valeur de modificateur n'a pas été correctement affecté a la durée du sort. Attendu : {dataSpell.AddOns.First().ModifierValue} | Actuel : {result.Duration}");
        }

        [Fact]
        public void TestConvertDataToBusiness_MultipleAddOnConversion()
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

            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -1,
                Name = "AddOn de Base pour les tests",
                Description = "AddOn pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Base
            });

            dataSpell.AddOns.Add(new Data.DataModels.AddOn()
            {
                Id = -2,
                Name = "AddOn de modifiant l'instabilité pour les tests",
                Description = "AddOn pour les Test unitaires, avec modification de l'Instabilité",
                InstabilityValue = 5,
                Type = Data.DataModels.Enums.AddOnTypeEnum.InstabilityOnly
            });

            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            Assert.True(result.AddOns.Count == 3, $"Erreur: Le nombre d'AddOn ajouté au sort est incorrect. Attendu : Nombre d'AddOn sur le spell [3] | Actuel : Nombre d'AddOn sur le spell [{result.AddOns.Count}]");
            Assert.True(result.TotalInstability == 2, $"Erreur: Le total d'instabilité n'a pas été correctement affecté par les AddOns. Attendu : 2 | Actuel : {result.TotalInstability}");
            Assert.True(result.Range != null, $"Erreur: La valeur de range n'a pas été ajouté au sort");
            Assert.True(result.Range == dataSpell.AddOns[0].ModifierValue, $"Erreur: La valeur de modificateur n'a pas été correctement affecté a la range du sort. Attendu : {dataSpell.AddOns[0].ModifierValue} | Actuel : {result.Range}");
        }

        [Fact]
        public void TestConvertDataToBusiness_NullValuesConversion()
        {
            Data.DataModels.Spell nullSpell = new Data.DataModels.Spell();

            var result = _spellConverter.ConvertDataToBusiness(nullSpell);

            Assert.True(result.Id == 0, $"Erreur: La valeur de Id n'est pas 0. Valeur pour Id : [{result.Id}]");
            Assert.True(result.Name == null, $"Erreur: La valeur de name n'est pas null. Valeur pour name : [{result.Name}] (Si rien n'est affiché entre les crochets, c'est peut-être une chaine vide)");
            Assert.True(result.ManaCost == 0, $"Erreur: La valeur de ManaCost n'est pas 0. Valeur pour ManaCost : [{result.ManaCost}]");
            Assert.True(result.Description == null, $"Erreur: La valeur de Description n'est pas null. Valeur pour Description : [{result.Description}] (Si rien n'est affiché entre les crochets, c'est peut-être une chaine vide)");
            Assert.True(result.AddOns != null, $"Erreur: La liste d'AddOns n'a pas éte generé pour l'objet buisness.");

            //Test de l'ajout des valeurs de initiales meme si le spell est null

            Assert.True(result.numericalLevel == SpellDefaults.DefaultNumericalLevel, $"Erreur: Le niveau numérique attendu est {SpellDefaults.DefaultNumericalLevel}, mais obtenu {result.numericalLevel}.");
            Assert.True(result.Range == SpellDefaults.DefaultRange, $"Erreur: La portée attendue est {SpellDefaults.DefaultRange}, mais obtenue {result.Range}.");
            Assert.True(result.CastTime == SpellDefaults.DefaultCastTime, $"Erreur: Le temps d'incantation attendu est {SpellDefaults.DefaultCastTime}, mais obtenu {result.CastTime}.");
            Assert.True(result.Duration == SpellDefaults.DefaultDuration, $"Erreur: La durée attendue est {SpellDefaults.DefaultDuration}, mais obtenue {result.Duration}.");
            Assert.True(result.Target == SpellDefaults.DefaultTarget, $"Erreur: La cible attendue est {SpellDefaults.DefaultTarget}, mais obtenue {result.Target}.");
            Assert.True(result.TotalInstability == SpellDefaults.DefaultTotalInstability, $"Erreur: L'instabilité totale attendue est {SpellDefaults.DefaultTotalInstability}, mais obtenue {result.TotalInstability}.");

        }

        [Fact]
        public void TestConvertDataToBusiness_NullAddOnConversion()
        {
            dataSpell.AddOns.Add(new Data.DataModels.AddOn());

            dataSpell.AddOns.Add(new Data.DataModels.AddOn());

            dataSpell.AddOns.Add(new Data.DataModels.AddOn());

            var result = _spellConverter.ConvertDataToBusiness(dataSpell);

            Assert.True(result.AddOns.Count > 0, $"Erreur: L'AddOn n'a pas été ajouté au sort");
            Assert.True(result.AddOns.Count == 3, $"Erreur: Le nombre d'AddOn ajouté au sort est incorrect. Attendu : Nombre d'AddOn sur le spell [3] | Actuel : Nombre d'AddOn sur le spell [{result.AddOns.Count}]");
            Assert.True(result.TotalInstability == SpellDefaults.DefaultTotalInstability, $"Erreur: L'instabilité totale attendue est {SpellDefaults.DefaultTotalInstability}, mais obtenue {result.TotalInstability}.");
            Assert.True(result.Range == SpellDefaults.DefaultRange, $"Erreur: La portée attendue est {SpellDefaults.DefaultRange}, mais obtenue {result.Range}.");
        }

    }
}
