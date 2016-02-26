using Axado.Models;

namespace Axado.DAO
{
    public class DbCreateDAO
    {
        public void CreateDb()
        {
            try
            {
                var db = new Context();
                db.Database.CreateIfNotExists();
                db.SaveChanges();

            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }
}