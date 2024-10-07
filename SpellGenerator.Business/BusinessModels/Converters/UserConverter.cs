using SpellGenerator.Business.BusinessModels.Converters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Business.BusinessModels.Converters
{
    public class UserConverter : IConverter<Data.DataModels.User, User>
    {
        MasteryConverter _masteryConverter = new MasteryConverter();
        MagicConverter _magicConverter = new MagicConverter();
        SpellConverter _spellConverter = new SpellConverter();
        public Data.DataModels.User ConvertBusinessToData(User buisnessUser)
        {
            Data.DataModels.User dataUser = new Data.DataModels.User();
            dataUser.Id = buisnessUser.Id;
            dataUser.Username = buisnessUser.Username;
            dataUser.Password = buisnessUser.Password;
            dataUser.Bio = buisnessUser.Bio;
            dataUser.Role = buisnessUser.Role;
            dataUser.KnownMasteries = new List<Data.DataModels.Mastery>();
            foreach(Mastery buisnessMastery in buisnessUser.KnownMasteries)
            {
                dataUser.KnownMasteries.Add(_masteryConverter.ConvertBusinessToData(buisnessMastery));
            }
            dataUser.KnownMagics = new List<Data.DataModels.Magic>();
            foreach (Magic buisnessMagic in buisnessUser.KnownMagics)
            {
                dataUser.KnownMagics.Add(_magicConverter.ConvertBusinessToData(buisnessMagic));
            }
            dataUser.SpellBook = new Data.DataModels.SpellBook();
            dataUser.SpellBook.Id = buisnessUser.SpellBook.Id;
            foreach(Spell businessSpell in buisnessUser.SpellBook.StoredSpells)
            {
                dataUser.SpellBook.StoredSpells.Add(_spellConverter.ConvertBusinessToData(businessSpell));
            }
            dataUser.SpellBookId = dataUser.SpellBook.Id;
            dataUser.SpellBook.User = dataUser;

            return dataUser;
        }

        public User ConvertDataToBusiness(Data.DataModels.User dataUser)
        {
            User buisnessUser = new User()
            {
                Id = dataUser.Id,
                Username = dataUser.Username,
                Password = dataUser.Password,
                Bio = dataUser.Bio,
                Role = dataUser.Role,
                SpellBook = new SpellBook()
                {
                    Id = dataUser.SpellBook.Id
                },
                KnownMagics = new List<Magic>(),
                KnownMasteries = new List<Mastery>()
            };

            foreach(Data.DataModels.Spell dataSpell in dataUser.SpellBook.StoredSpells)
            {
                buisnessUser.SpellBook.StoredSpells.Add(_spellConverter.ConvertDataToBusiness(dataSpell));
            }
            foreach(Data.DataModels.Magic magic in dataUser.KnownMagics)
            {
                buisnessUser.KnownMagics.Add(_magicConverter.ConvertDataToBusiness(magic));
            }
            foreach (Data.DataModels.Mastery mastery in dataUser.KnownMasteries)
            {
                buisnessUser.KnownMasteries.Add(_masteryConverter.ConvertDataToBusiness(mastery));
            }

            return buisnessUser;
        }
    }
}
