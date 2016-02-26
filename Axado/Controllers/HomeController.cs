using Axado.DAO;
using System.Web.Mvc;

namespace Axado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dbCreate = new DbCreateDAO();
            dbCreate.CreateDb();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}