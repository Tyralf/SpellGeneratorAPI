using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.Converters.Interfaces
{
    public interface IConverter<TData, TBusiness>
    {
        public TData ConvertBusinessToData(TBusiness buisnessModel);
        public TBusiness ConvertDataToBusiness(TData dataModel);
    }
}
