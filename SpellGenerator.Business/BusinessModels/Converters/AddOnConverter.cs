using SpellGenerator.Business.BusinessModels.AddOns;
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
            BasicAddOn businessAddOn;

            switch(dataAddOn.Type)
            {
                case AddOnTypeEnum.InstabilityOnly:
                    InstabilityModifierAddOn instabilityAddOn = new InstabilityModifierAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description,
                        InstabilityModificationValue = dataAddOn.InstabilityValue
                    };

                    return instabilityAddOn;

                case AddOnTypeEnum.Range:
                    RangeModifierAddOn rangeAddOn = new RangeModifierAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description,
                        InstabilityModificationValue = dataAddOn.InstabilityValue,
                        RangeModificationValue = dataAddOn.ModifierValue
                    };
                    return rangeAddOn;

                case AddOnTypeEnum.Cast:
                    CastModifierAddOn castAddOn = new CastModifierAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description,
                        InstabilityModificationValue = dataAddOn.InstabilityValue,
                        CastModificationValue = dataAddOn.ModifierValue
                    };
                    return castAddOn;

                case AddOnTypeEnum.Target:
                    TargetModifierAddOn targetAddOn = new TargetModifierAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description,
                        InstabilityModificationValue = dataAddOn.InstabilityValue,
                        TargetModificationValue = dataAddOn.ModifierValue
                    };
                    return targetAddOn;

                case AddOnTypeEnum.Duration:
                    DurationModifierAddOn durationAddOn = new DurationModifierAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description,
                        InstabilityModificationValue = dataAddOn.InstabilityValue,
                        DurationModificationValue = dataAddOn.ModifierValue
                    };
                    return durationAddOn;

                default:
                    businessAddOn = new BasicAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description
                    };
                    break;

            }

            return businessAddOn;
        }
    }
}
