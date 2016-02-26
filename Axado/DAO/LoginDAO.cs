using Axado.Models;
using System.Linq;

namespace Axado.DAO
{
    public class LoginDAO
    {
        private Context db;
        public LoginDAO(Context db)
        {
            this.db = db;
        }
        public bool Login(User user)
        {
            return db.User.Any(x => x.Name == user.Name && x.Password == user.Password);
        }
    }
}