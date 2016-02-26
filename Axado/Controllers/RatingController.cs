using Axado.Domain;
using Axado.Models;
using System;
using System.Web.Mvc;

namespace Axado.Controllers
{
    public class RatingController : Controller
    {
        private RatingDomain ratingDomain;

        public ActionResult Index()
        {
            ratingDomain = new RatingDomain();
            return View(ratingDomain.GetCarrierRatings());

        }

        public ActionResult CarrierRating(int id)
        {
            var ratingDomain = new RatingDomain();
            return View(ratingDomain.GetCarrierRatings());
        }

        [HttpPost]
        public ActionResult Rate(string idCarrier)
        {
            int userId = Convert.ToInt32(HttpContext.Session["UserId"]);
            ratingDomain = new RatingDomain();
            ratingDomain.Rate(Convert.ToInt32(idCarrier), userId);

            return RedirectToAction("Index");
        }

    }
}
