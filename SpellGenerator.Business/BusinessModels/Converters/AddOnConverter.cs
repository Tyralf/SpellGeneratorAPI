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
            Data.DataModels.AddOn dataAddOn = new Data.DataModels.AddOn();

            switch (businessAddOn)
            {

                case RangeModifierAddOn rangeAddOn:
                    dataAddOn.Id = rangeAddOn.Id;
                    dataAddOn.Name = rangeAddOn.Name;
                    dataAddOn.Description = rangeAddOn.Description;
                    dataAddOn.Type = AddOnTypeEnum.Range;
                    dataAddOn.InstabilityValue = rangeAddOn.InstabilityModificationValue;
                    dataAddOn.ModifierValue = rangeAddOn.RangeModificationValue;

                    break;

                case TargetModifierAddOn targetAddOn:
                    dataAddOn.Id = targetAddOn.Id;
                    dataAddOn.Name = targetAddOn.Name;
                    dataAddOn.Description = targetAddOn.Description;
                    dataAddOn.Type = AddOnTypeEnum.Target;
                    dataAddOn.InstabilityValue = targetAddOn.InstabilityModificationValue;
                    dataAddOn.ModifierValue = targetAddOn.TargetModificationValue;

                    break;

                case CastModifierAddOn castAddOn:
                    dataAddOn.Id = castAddOn.Id;
                    dataAddOn.Name = castAddOn.Name;
                    dataAddOn.Description = castAddOn.Description;
                    dataAddOn.Type = AddOnTypeEnum.Cast;
                    dataAddOn.InstabilityValue = castAddOn.InstabilityModificationValue;
                    dataAddOn.ModifierValue = castAddOn.CastModificationValue;

                    break;

                case DurationModifierAddOn DurationAddOn:
                    dataAddOn.Id = DurationAddOn.Id;
                    dataAddOn.Name = DurationAddOn.Name;
                    dataAddOn.Description = DurationAddOn.Description;
                    dataAddOn.Type = AddOnTypeEnum.Duration;
                    dataAddOn.InstabilityValue = DurationAddOn.InstabilityModificationValue;
                    dataAddOn.ModifierValue = DurationAddOn.DurationModificationValue;

                    break;

                case InstabilityModifierAddOn instabilityAddOn:
                    dataAddOn.Id = instabilityAddOn.Id;
                    dataAddOn.Name = instabilityAddOn.Name;
                    dataAddOn.Description = instabilityAddOn.Description;
                    dataAddOn.Type = AddOnTypeEnum.InstabilityOnly;
                    dataAddOn.InstabilityValue = instabilityAddOn.InstabilityModificationValue;

                    break;

                case BasicAddOn basicAddOn:
                    dataAddOn.Id = basicAddOn.Id;
                    dataAddOn.Name = basicAddOn.Name;
                    dataAddOn.Description = basicAddOn.Description;
                    dataAddOn.Type = AddOnTypeEnum.Base;

                    break;
            }

            return dataAddOn;
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
