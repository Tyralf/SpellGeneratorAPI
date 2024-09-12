﻿using SpellGenerator.Business.BusinessModels.AddOns;
using SpellGenerator.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public int numericalLevel { get; set; }
        public int TotalInstability { get; set; }
        public int ManaCost { get; set; }
        public string Range { get; set; }
        public string Duration { get; set; }
        public string Target { get; set; }
        public string CastTime { get; set; }
        public string Description { get; set; }
        public List<Magic> RequieredMagics { get; set; }
        public List<Mastery> RequieredMasteries { get; set; }
        public List<IAddOn> AddOns { get; set; }
    }
}