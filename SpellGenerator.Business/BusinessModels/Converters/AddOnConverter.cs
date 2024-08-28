using SpellGenerator.Business.BusinessModels.AddOnDecorators;
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using SpellGenerator.Business.Interfaces;
using SpellGenerator.Data.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.Converters
{
    internal class AddOnConverter : IConverter<Data.DataModels.AddOn, IAddOn>
    {
        public Data.DataModels.AddOn ConvertBusinessToData(IAddOn businessAddOn)
        {
            throw new NotImplementedException();
        }

        public IAddOn ConvertDataToBusiness(Data.DataModels.AddOn dataAddOn)
        {
            IAddOn businessAddOn = new AddOn()
            {
                Id = dataAddOn.Id,
                Name = dataAddOn.Name,
                Description = dataAddOn.Description
            };
            if (dataAddOn.Type == AddOnTypeEnum.InstabilityOnly)
            {
                businessAddOn = new InstabilityModifierDecorator(businessAddOn)
                {
                    InstabilityModification = dataAddOn.InstabilityValue
                };
            }
            else if (dataAddOn.Type == AddOnTypeEnum.Range)
            {
                businessAddOn = new RangeModifierDecorator(businessAddOn)
                {
                    InstabilityModification = dataAddOn.InstabilityValue,
                    RangeModification = dataAddOn.ModifierValue
                };
            }
            return businessAddOn;
        }
    }
}
