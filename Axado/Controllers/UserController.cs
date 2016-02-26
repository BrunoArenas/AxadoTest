using Axado.DAO;
using Axado.Models;
using System.Web.Mvc;

namespace Axado.Controllers
{
    public class UserController : Controller
    {

        private UserDAO dao;
        public UserController(UserDAO dao)
        {
            this.dao = dao;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            return View("NewUser");
        }

        [HttpPost]
        public ActionResult Create(User usr)
        {

            dao.Create(usr);

            return RedirectToAction("Index", "Login");
        }
    }
}
