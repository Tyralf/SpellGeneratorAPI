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
            Type = Data.DataModels.Enums.AddOnTypeEnum.Base,
            InstabilityValue = 10,
            ModifierValue = "test"
        };

        public AddOnDataToBuisnessConverterTests()
        {
            _addOnConverter = new AddOnConverter();
        }

    }
}
