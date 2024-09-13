using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.Converters
{
    public class MasteryConverter : IConverter<Data.DataModels.Mastery, Mastery>
    {
        public Data.DataModels.Mastery ConvertBusinessToData(Mastery buisnessMastery)
        {
            Data.DataModels.Mastery result = new Data.DataModels.Mastery()
            {
                Id = buisnessMastery.Id,
                Name = buisnessMastery.Name,
            };

            if(buisnessMastery.ParentMastery != null)
            {
                result.ParentMastery = ConvertBusinessToData(buisnessMastery.ParentMastery);
            }
            return result;
        }

        public Mastery ConvertDataToBusiness(Data.DataModels.Mastery dataMastery)
        {
            Mastery result = new Mastery()
            {
                Id = dataMastery.Id,
                Name = dataMastery.Name,
            };

            if (dataMastery.ParentMastery != null)
            {
                result.ParentMastery = ConvertDataToBusiness(dataMastery.ParentMastery);
            }
            return result;
        }
    }
}
