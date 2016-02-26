using Axado.Models;
using System.Linq;


namespace Axado.DAO
{
    public class UserDAO
    {
        private Context db;

        public UserDAO(Context db)
        {
            this.db = db;
        }

        public void Create(User user)
        {
            if (!db.User.Any(x => x.Name == user.Name))
            {
                var novousuario = new User() { Name = user.Name, Password = user.Password };
                db.User.Add(novousuario);
                db.SaveChanges();
            }
            
        }

        public int GetUserIdPerName(string name)
        {
            return db.User.FirstOrDefault(x => x.Name == name).Id;
        }

    }
}