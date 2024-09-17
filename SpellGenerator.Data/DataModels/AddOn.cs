using SpellGenerator.Data.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class AddOn
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public AddOnTypeEnum Type { get; set; }
        public int InstabilityValue { get; set; }
        public string? ModifierValue { get; set; }
        public List<Spell>? Spells { get; set; }
    }
}
