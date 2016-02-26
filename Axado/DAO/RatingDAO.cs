using Axado.Models;
using System.Collections.Generic;
using System.Linq;

namespace Axado.DAO
{
    public class RatingDAO
    {
        private Context db;
        public RatingDAO(Context db)
        {
            this.db = db;
        }
        public void Create(Rating rate)
        {
            db.Rating.Add(rate);
            db.SaveChanges();
        }

        public List<Rating> GetRatingList()
        {
            return db.Rating.ToList();
        }
        public void Delete(int IdRating)
        {
            db.Rating.Remove(db.Rating.FirstOrDefault(x => x.ID == IdRating));
            db.SaveChanges();
        }
    }
}