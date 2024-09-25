using Microsoft.EntityFrameworkCore;
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

        public void AddSpell(Spell spellInfo)
        {
            // Ajout du sort dans le contexte
            _dbContext.Spells.Add(spellInfo);

            // Sauvegarde les changements dans la base de données
            _dbContext.SaveChanges();
        }

        public Spell ModifySpell(Spell modifiedInfo, int id)
        {
            // Trouve le sort correspondant à l'ID donné
            var spell = _dbContext.Spells.FirstOrDefault(s => s.Id == id);

            if (spell == null)
            {
                throw new KeyNotFoundException("Le Sort n'a pas été trouvé dans la base de donnée");
            }

            // Mise à jour des propriétés du sort
            spell.Name = modifiedInfo.Name;
            spell.ManaCost = modifiedInfo.ManaCost;
            spell.Description = modifiedInfo.Description;
            spell.RequieredMagics = modifiedInfo.RequieredMagics;
            spell.RequieredMasteries = modifiedInfo.RequieredMasteries;
            spell.AddOns = modifiedInfo.AddOns;

            // Sauvegarde les modifications dans la base de données
            _dbContext.SaveChanges();

            return spell;
        }

        public void DeleteSpell(int id)
        {
            var spell = _dbContext.Spells.FirstOrDefault(s => s.Id == id);

            if (spell == null)
            {
                throw new KeyNotFoundException("Le Sort n'a pas été trouvé dans la base de donnée");
            }

            // Supprime le sort du contexte
            _dbContext.Spells.Remove(spell);

            // Sauvegarde les changements dans la base de données
            _dbContext.SaveChanges();
        }

        public List<Spell> GetAllSpellsFromSpellBook(int userId, int spellBookId)
        {
            var spellBook = _dbContext.SpellBooks
                            .FirstOrDefault(sb => sb.Id == spellBookId && sb.User.Id == userId);

            if (spellBook == null)
            {
                throw new KeyNotFoundException(" Le SpellBook de cet utilisateur n'a pas été trouvé dans la base de donnée");
            }

            // Récupère tous les sorts du SpellBook
            var spells = _dbContext.Spells
                .Where(s => s.SpellBooks.Contains(spellBook))
                .ToList();

            return spells;
        }



        public void CreateFakeAddOns()
        {
            AddOn FakeSimpleAddOn = new AddOn()
            {
                Name = "Simple",
                Description = "This AddOn is a simple addOn To Test Developpement",
                Type = AddOnTypeEnum.Base
            };

            AddOn FakeInstabilityModifierAddOn = new AddOn()
            {
                Name = "Instability Modifier",
                Description = "This AddOn an addOn that modify Instability but nothing else, like a condition -Only possible to cast during the night- To Test Developpement",
                Type = AddOnTypeEnum.InstabilityOnly,
                InstabilityValue = -5
            };

            AddOn FakeRangeModifierAddOn = new AddOn()
            {
                Name = "Portée à 25m",
                Description = "This AddOn an addOn that modify Instability and Range To Test Developpement",
                Type = AddOnTypeEnum.Range,
                InstabilityValue = -3,
                ModifierValue = "Range is now 25m"
            };

            // Ajouter les objets AddOn dans la base de données
            _dbContext.AddOns.Add(FakeSimpleAddOn);
            _dbContext.AddOns.Add(FakeInstabilityModifierAddOn);
            _dbContext.AddOns.Add(FakeRangeModifierAddOn);

            // Sauvegarder les modifications dans la base de données
            _dbContext.SaveChanges();


        }

        public void CreateFakeSpell()
        {


        }
        /*public Spell FakeGetSpell()
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
        }*/
    }
}
