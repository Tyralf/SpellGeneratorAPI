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

            Assert.IsAssignableFrom< Business.Interfaces.IAddOn>(result);

            Assert.IsType<Business.BusinessModels.AddOn>(result);
        }

        [Fact]
        public void TestConvertDataAddOnToBusinessAddOn_BasicDataTransfer()
        {
            var result = _addOnConverter.ConvertDataToBusiness(addOnTest);
            // Assure que le type est bien AddOn
            var addOnResult = result as Business.BusinessModels.AddOn;
            Assert.NotNull(addOnResult);

            // Vérifie les propriétés spécifiques
            Assert.Equal(addOnTest.Name, addOnResult.Name);

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

            Assert.IsAssignableFrom<Business.Interfaces.IAddOn>(result);
            var InstabilityResult = Assert.IsType<Business.BusinessModels.AddOnDecorators.InstabilityModifierDecorator>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(InstabilityAddOnTest.Id, InstabilityResult.Id);
            Assert.Equal(InstabilityAddOnTest.Name, InstabilityResult.Name);
            Assert.Equal(InstabilityAddOnTest.Description, InstabilityResult.Description);
            Assert.Equal(InstabilityAddOnTest.InstabilityValue, InstabilityResult.InstabilityModification);



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
            Assert.IsType<Business.BusinessModels.AddOnDecorators.RangeModifierDecorator>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(RangeAddOnTest.Id, result.Id);
            Assert.Equal(RangeAddOnTest.Name, result.Name);
            Assert.Equal(RangeAddOnTest.Description, result.Description);

            var resultDecorator = result as Business.BusinessModels.AddOnDecorators.RangeModifierDecorator;

            Assert.Equal(RangeAddOnTest.InstabilityValue, resultDecorator.InstabilityModification);
            Assert.Equal(RangeAddOnTest.ModifierValue, resultDecorator.RangeModification);
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
            Assert.IsType<Business.BusinessModels.AddOnDecorators.TargetModifierDecorator>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(TargetAddOnTest.Id, result.Id);
            Assert.Equal(TargetAddOnTest.Name, result.Name);
            Assert.Equal(TargetAddOnTest.Description, result.Description);

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
            Assert.IsType<Business.BusinessModels.AddOnDecorators.CastModifierDecorator>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(CastAddOnTest.Id, result.Id);
            Assert.Equal(CastAddOnTest.Name, result.Name);
            Assert.Equal(CastAddOnTest.Description, result.Description);

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
            Assert.IsType<Business.BusinessModels.AddOnDecorators.DurationModifierDecorator>(result);

            // Vérifie les propriétés spécifiques
            Assert.Equal(DurationAddOnTest.Id, result.Id);
            Assert.Equal(DurationAddOnTest.Name, result.Name);
            Assert.Equal(DurationAddOnTest.Description, result.Description);

        }

    }
}
