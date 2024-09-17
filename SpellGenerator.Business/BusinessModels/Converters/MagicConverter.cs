
using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.Converters
{
    public class MagicConverter : IConverter<Data.DataModels.Magic, Magic>
    {
        public Data.DataModels.Magic ConvertBusinessToData(Magic buisnessMagic)
        {

            return new Data.DataModels.Magic()
            {
                Id = buisnessMagic.Id,
                Name = buisnessMagic.Name
            };
        }

        public Magic ConvertDataToBusiness(Data.DataModels.Magic dataMagic)
        {
            return new Magic()
            {
                Id = dataMagic.Id,
                Name = dataMagic.Name
            };
        }
    }
}
