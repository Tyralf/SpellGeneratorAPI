using SpellGenerator.Data.DataModels;

namespace SpellGenerator.Data.Repositories
{
    public class UserRepository
    {
        MyDbContext _dbContext;
        public UserRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void AddUser(User UserInfo)
        {
            SpellBook userSpellBook = new SpellBook()
            {
                User = UserInfo
            };
            UserInfo.SpellBook = userSpellBook;
            // Ajout du sort dans le contexte
            _dbContext.Users.Add(UserInfo);
            _dbContext.SpellBooks.Add(userSpellBook);

            // Sauvegarde les changements dans la base de données
            _dbContext.SaveChanges();
        }
    }
}
