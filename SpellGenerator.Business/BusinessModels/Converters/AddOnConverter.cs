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

                /*case AddOnTypeEnum.Cast:
                    IAddOn businessAddOn = new BasicAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description
                    };
                    break;

                case AddOnTypeEnum.Target:
                    IAddOn businessAddOn = new BasicAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description
                    };
                    break;

                case AddOnTypeEnum.Duration:
                    IAddOn businessAddOn = new BasicAddOn()
                    {
                        Id = dataAddOn.Id,
                        Name = dataAddOn.Name,
                        Description = dataAddOn.Description
                    };
                    break;*/

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
