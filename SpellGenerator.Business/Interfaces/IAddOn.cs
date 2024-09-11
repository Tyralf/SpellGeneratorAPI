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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Apply(Spell spell);
    }
}
