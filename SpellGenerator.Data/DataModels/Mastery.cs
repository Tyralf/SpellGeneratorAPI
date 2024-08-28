using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.DataModels
{
    public class Mastery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Mastery ParentMastery { get; set; }
    }
}
