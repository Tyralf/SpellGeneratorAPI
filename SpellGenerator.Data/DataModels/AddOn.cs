using SpellGenerator.Data.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class AddOn
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AddOnTypeEnum Type { get; set; }
        public int InstabilityValue { get; set; }
        public string ModifierValue { get; set; }
    }
}
