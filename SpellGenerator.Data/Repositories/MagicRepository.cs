using Microsoft.EntityFrameworkCore;
using SpellGenerator.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.Data.Repositories
{
    public class MagicRepository
    {
        MyDbContext _dbContext;
        public MagicRepository(MyDbContext context)
        {
            _dbContext = context;
        }
        public void AddMagic(Magic magicInfo)
        {
            var existingMagic = _dbContext.Magics
                                    .FirstOrDefault(m => m.Name == magicInfo.Name);

            if (existingMagic != null)
            {
                // Si une magie avec ce nom existe déjà, tu peux lever une exception ou gérer l'erreur comme tu le souhaites
                throw new InvalidOperationException("Une magie avec ce nom existe déjà.");
            }
            // Ajout du sort dans le contexte
            _dbContext.Magics.Add(magicInfo);

            // Sauvegarde les changements dans la base de données
            _dbContext.SaveChanges();
        }
    }
}
