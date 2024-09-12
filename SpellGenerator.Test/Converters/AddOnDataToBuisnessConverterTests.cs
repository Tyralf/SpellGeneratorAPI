using Microsoft.AspNetCore.Mvc.RazorPages;
using SpellGenerator.Business.BusinessModels.AddOns;
using SpellGenerator.Business.BusinessModels.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Test.Converters
{
    public class AddOnDataToBuisnessConverterTests
    {
        private readonly AddOnConverter _addOnConverter;
        private Data.DataModels.AddOn addOnTest = new Data.DataModels.AddOn()
        {
            Id = -1,
            Name = "AddOn de Base pour les tests",
            Description = "AddOn pour les Test unitaires",
            Type = Data.DataModels.Enums.AddOnTypeEnum.Base
        };

        public AddOnDataToBuisnessConverterTests()
        {
            _addOnConverter = new AddOnConverter();
        }

        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_OutputType()
        {
            var result = _addOnConverter.ConvertDataToBusiness(addOnTest);

            Assert.IsType<BasicAddOn>(result);
        }

        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_BasicDataTransfer()
        {
            var result = _addOnConverter.ConvertDataToBusiness(addOnTest);
            BasicAddOn BasicResult = Assert.IsType<BasicAddOn>(result);

            Assert.Equal(addOnTest.Name, BasicResult.Name);
        }

        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_InstabilityAddOn()
        {

            Data.DataModels.AddOn InstabilityAddOnTest = new Data.DataModels.AddOn()
            {
                Id = -2,
                Name = "Instability Only AddOn pour les tests",
                Description = "AddOn ne modifiant que l'instabilité pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.InstabilityOnly,
                InstabilityValue = 5,
            };

            var result = _addOnConverter.ConvertDataToBusiness(InstabilityAddOnTest);
            var InstabilityResult = Assert.IsType<InstabilityModifierAddOn>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(InstabilityAddOnTest.Id, InstabilityResult.Id);
            Assert.Equal(InstabilityAddOnTest.Name, InstabilityResult.Name);
            Assert.Equal(InstabilityAddOnTest.Description, InstabilityResult.Description);
            Assert.Equal(InstabilityAddOnTest.InstabilityValue, InstabilityResult.InstabilityModificationValue);


        }
        
        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_RangeAddOn()
        {
            Data.DataModels.AddOn RangeAddOnTest = new Data.DataModels.AddOn()
            {
                Id = -3,
                Name = "Range AddOn pour les tests",
                Description = "AddOn de portée pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Range,
                InstabilityValue = 10,
                ModifierValue = "Nouvelle Portée"
            };
            var result = _addOnConverter.ConvertDataToBusiness(RangeAddOnTest);

            Assert.IsAssignableFrom<Business.Interfaces.IAddOn>(result);
            var RangeResult = Assert.IsType<RangeModifierAddOn>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(RangeAddOnTest.Id, RangeResult.Id);
            Assert.Equal(RangeAddOnTest.Name, RangeResult.Name);
            Assert.Equal(RangeAddOnTest.Description, RangeResult.Description);
            Assert.Equal(RangeAddOnTest.InstabilityValue, RangeResult.InstabilityModificationValue);
            Assert.Equal(RangeAddOnTest.ModifierValue, RangeResult.RangeModificationValue);
        }
        
        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_TargetAddOn()
        {
            Data.DataModels.AddOn TargetAddOnTest = new Data.DataModels.AddOn()
            {
                Id = -5,
                Name = "Target AddOn pour les tests",
                Description = "AddOn de cibles pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Target,
                InstabilityValue = 8,
                ModifierValue = "Nouveau nombre de cibles"
            };

            var result = _addOnConverter.ConvertDataToBusiness(TargetAddOnTest);

            Assert.IsAssignableFrom<Business.Interfaces.IAddOn>(result);
            var TargetResult = Assert.IsType<TargetModifierAddOn>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(TargetAddOnTest.Id, TargetResult.Id);
            Assert.Equal(TargetAddOnTest.Name, TargetResult.Name);
            Assert.Equal(TargetAddOnTest.Description, TargetResult.Description);
            Assert.Equal(TargetAddOnTest.InstabilityValue, TargetResult.InstabilityModificationValue);
            Assert.Equal(TargetAddOnTest.ModifierValue, TargetResult.TargetModificationValue);

        }

        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_CastAddOn()
        {
            Data.DataModels.AddOn CastAddOnTest = new Data.DataModels.AddOn()
            {
                Id = -4,
                Name = "Cast AddOn pour les tests",
                Description = "AddOn de temps de cast pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Cast,
                InstabilityValue = 4,
                ModifierValue = "Nouvelle temps de cast"
            };
            var result = _addOnConverter.ConvertDataToBusiness(CastAddOnTest);

            Assert.IsAssignableFrom<Business.Interfaces.IAddOn>(result);
            var CastResult = Assert.IsType<CastModifierAddOn>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(CastAddOnTest.Id, CastResult.Id);
            Assert.Equal(CastAddOnTest.Name, CastResult.Name);
            Assert.Equal(CastAddOnTest.Description, CastResult.Description);
            Assert.Equal(CastAddOnTest.InstabilityValue, CastResult.InstabilityModificationValue);
            Assert.Equal(CastAddOnTest.ModifierValue, CastResult.CastModificationValue);

        }

        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_DurationAddOn()
        {
            Data.DataModels.AddOn DurationAddOnTest = new Data.DataModels.AddOn()
            {
                Id = -6,
                Name = "Duration AddOn pour les tests",
                Description = "AddOn de durée pour les Test unitaires",
                Type = Data.DataModels.Enums.AddOnTypeEnum.Duration,
                InstabilityValue = 6,
                ModifierValue = "Nouvelle durée"
            };

            var result = _addOnConverter.ConvertDataToBusiness(DurationAddOnTest);

            Assert.IsAssignableFrom<Business.Interfaces.IAddOn>(result);
            var DurationResult = Assert.IsType<DurationModifierAddOn>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(DurationAddOnTest.Id, DurationResult.Id);
            Assert.Equal(DurationAddOnTest.Name, DurationResult.Name);
            Assert.Equal(DurationAddOnTest.Description, DurationResult.Description);
            Assert.Equal(DurationAddOnTest.InstabilityValue, DurationResult.InstabilityModificationValue);
            Assert.Equal(DurationAddOnTest.ModifierValue, DurationResult.DurationModificationValue);

        }

    }
}
