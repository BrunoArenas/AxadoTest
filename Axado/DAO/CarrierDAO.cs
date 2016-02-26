using Axado.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Axado.DAO
{
    public class CarrierDAO
    {
        private Context db;
        public CarrierDAO(Context db)
        {
            this.db = db;

        }
        public List<Carrier> List()
        {
            return db.Carrier.ToList();
        }

        public void Create(Carrier carrier)
        {
            db.Carrier.Add(carrier);
            db.SaveChanges();
        }

        public void Delete(int idCarrier)
        {
            db.Carrier.Remove(db.Carrier.Single(x => x.Id == idCarrier));
            db.Rating.RemoveRange(db.Rating.Where(x => x.CarrierId == idCarrier));
            db.SaveChanges();
        }

        public void Update(int idCarrier, Carrier carrier)
        {
            var newCarrier = db.Carrier.Single(x => x.Id == idCarrier);
            newCarrier.Nome = carrier.Nome;
            db.SaveChanges();
        }



    }
}