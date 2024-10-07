using SpellGenerator.Data.DataModels;

namespace SpellGenerator.Data.Repositories
{
    public class AddOnRepository
    {
        MyDbContext _dbContext;
        public AddOnRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<AddOn> GetAllAddOns()
        {
            return _dbContext.AddOns.ToList();
        }

        public void AddAddOn(AddOn AddOnInfo)
        {
            // Ajout du sort dans le contexte
            _dbContext.AddOns.Add(AddOnInfo);

            // Sauvegarde les changements dans la base de données
            _dbContext.SaveChanges();
        }
    }
}
