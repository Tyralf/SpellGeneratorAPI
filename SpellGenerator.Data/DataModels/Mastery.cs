using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class Mastery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public Mastery ParentMastery { get; set; }

        public List<Spell> Spells { get; set; } = new List<Spell>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
