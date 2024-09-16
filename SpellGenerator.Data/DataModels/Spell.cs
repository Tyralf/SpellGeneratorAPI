using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class Spell
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int ManaCost { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public List<Magic> RequieredMagics { get; set; } = new List<Magic>();
        [Required]
        public List<Mastery> RequieredMasteries { get; set; } = new List<Mastery>();
        public List<AddOn> AddOns { get; set; } = new List<AddOn>();
        public List<SpellBook> SpellBooks { get; set; } = new List<SpellBook>();
    }
}
