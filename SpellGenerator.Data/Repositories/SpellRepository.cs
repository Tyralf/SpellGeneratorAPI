using SpellGenerator.Data.DataModels;
using SpellGenerator.Data.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.Repositories
{
    public class SpellRepository
    {
        MyDbContext _dbContext;
        public SpellRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<Spell> GetAllSpells()
        {
            return _dbContext.Spells.ToList();
        }
        public Spell FakeGetSpell()
        {
            Magic fakeFireMagic = new Magic()
            {
                Id = -1,
                Name = "Fake Fire Magic"
            };

            Magic fakeDarkMagic = new Magic()
            {
                Id = -3,
                Name = "Fake Dark Magic"
            };

            Mastery fakeEvocationMastery = new Mastery()
            {
                Id = -1,
                Name = "Fake Evocation"
            };

            Mastery fakeInvocationMastery = new Mastery()
            {
                Id = -2,
                Name = "Fake Invocation",
                ParentMastery = fakeEvocationMastery
            };

            AddOn FakeSimpleAddOn = new AddOn()
            {
                Id = -1,
                Name = "Simple",
                Description = "This AddOn is a simple addOn To Test Developpement",
                Type = AddOnTypeEnum.Base
            };

            AddOn FakeInstabilityModifierAddOn = new AddOn()
            {
                Id = -1,
                Name = "Instability Modifier",
                Description = "This AddOn an addOn that modify Instability but nothing else, like a condition -Only possible to cast during the night- To Test Developpement",
                Type = AddOnTypeEnum.InstabilityOnly,
                InstabilityValue = -5
            };

            AddOn FakeRangeModifierAddOn = new AddOn()
            {
                Id = -1,
                Name = "Portée à 25m",
                Description = "This AddOn an addOn that modify Instability and Range To Test Developpement",
                Type = AddOnTypeEnum.Range,
                InstabilityValue = -3,
                ModifierValue = "Range is now 25m"
            };

            Spell fakeSpell = new Spell();
            fakeSpell.Id = -1;
            fakeSpell.Name = "The FakeSpell";
            fakeSpell.Description = "This is a fake spell made for developpement !";
            fakeSpell.RequieredMagics = new List<Magic>()
            {
                fakeFireMagic,
                fakeDarkMagic
            };
            fakeSpell.RequieredMasteries = new List<Mastery>()
            {
                fakeInvocationMastery,
                fakeEvocationMastery
            };
            fakeSpell.AddOns = new List<AddOn>()
            {
                FakeSimpleAddOn,
                FakeInstabilityModifierAddOn,
                FakeRangeModifierAddOn
            };

            return fakeSpell;
        }
    }
}
