using Newtonsoft.Json;
using SpellGenerator.Business.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.Interfaces
{
    [JsonObject]
    public interface IAddOn
    {
        public void Apply(Spell spell);
    }
}
