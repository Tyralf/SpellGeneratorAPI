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
    public class AddOnConverter : IConverter<Data.DataModels.AddOn, IAddOn>
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

            switch(dataAddOn.Type)
            {
                case AddOnTypeEnum.InstabilityOnly:
                    businessAddOn = new InstabilityModifierDecorator(businessAddOn)
                    {
                        InstabilityModification = dataAddOn.InstabilityValue
                    };
                    break;

                case AddOnTypeEnum.Range:
                    businessAddOn = new RangeModifierDecorator(businessAddOn)
                    {
                        InstabilityModification = dataAddOn.InstabilityValue,
                        RangeModification = dataAddOn.ModifierValue
                    };
                    break;

                case AddOnTypeEnum.Cast:
                    businessAddOn = new CastModifierDecorator(businessAddOn)
                    {
                        InstabilityModification = dataAddOn.InstabilityValue,
                        CastModification = dataAddOn.ModifierValue
                    };
                    break;

                case AddOnTypeEnum.Target:
                    businessAddOn = new TargetModifierDecorator(businessAddOn)
                    {
                        InstabilityModification = dataAddOn.InstabilityValue,
                        TargetModification = dataAddOn.ModifierValue
                    };
                    break;

                case AddOnTypeEnum.Duration:
                    businessAddOn = new DurationModifierDecorator(businessAddOn)
                    {
                        InstabilityModification = dataAddOn.InstabilityValue,
                        DurationModification = dataAddOn.ModifierValue
                    };
                    break;

            }

            return businessAddOn;
        }
    }
}
