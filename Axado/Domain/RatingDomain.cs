using Axado.Models;
using Axado.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axado.ViewModel;

namespace Axado.Domain
{

    public class RatingDomain
    {
        private RatingDAO ratingDao;
        private Context db;
        private CarrierDAO carrierDao;

        public RatingDomain()
        {
            privateSetsContructor();
        }

        private void privateSetsContructor()
        {
            db = new Context();
            ratingDao = new RatingDAO(db);
            carrierDao = new CarrierDAO(db);
        }

        public void Rate(int idCarrier, int userId)
        {
            var db = new Context();
            var dao = new RatingDAO(db);

            try
            {
                if (db.Rating.Any(X => X.UserId == userId))
                {
                   ratingDao.Delete(db.Rating.FirstOrDefault(x => x.UserId == userId).ID);
                }

                var newRate = new Rating
                {
                    CarrierId = idCarrier,
                    UserId = userId,
                    IncludeDate = DateTime.Now
                };

                dao.Create(newRate);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    public List<RatingViewModel> GetCarrierRatings()
    {
        var viewModelList = new List<RatingViewModel>();

        var carrierList = carrierDao.List();

        foreach (var carrier in carrierList)
        {
            viewModelList.Add(
                new RatingViewModel
                {
                    CarrierId = carrier.Id,
                    CarrierName = carrier.Nome,
                    Percent = GetPercentPerCarrier(carrier.Id),
                    Rates = GetRatesQttperIdCarrrier(carrier.Id).ToString()
                });
        }

        return viewModelList;
    }

    private string GetPercentPerCarrier(int idCarrier)
    {
        var ratesQttPerCarrier = GetRatesQttperIdCarrrier(idCarrier);
        var ratesTotal = db.Rating.Count();

        if (ratesTotal == 0)
            return "0.0%";

        var percentage = Math.Round(Convert.ToDecimal(ratesQttPerCarrier) / Convert.ToDecimal(ratesTotal) * 100);
        return string.Concat(percentage.ToString(), "%");
    }

    private int GetRatesQttperIdCarrrier(int idCarrier)
    {
        return db.Rating.Count(x => x.CarrierId == idCarrier);
    }




}
}