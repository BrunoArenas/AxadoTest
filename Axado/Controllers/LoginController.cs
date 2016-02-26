using Axado.Models;
using Axado.DAO;
using System.Web.Mvc;

namespace Axado.Controllers
{
    public class LoginController : Controller
    {
        private LoginDAO loginDao;
        private UserDAO userDao;
        public LoginController(LoginDAO loginDao, UserDAO userDao)
        {
            this.loginDao = loginDao;
            this.userDao = userDao;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (loginDao.Login(user))
            {
                // i hate to use session in mvc, but im in a hurry! so please apologize me for that. Thank you :)
                Session["UserId"] =  userDao.GetUserIdPerName(user.Name);
       
                return RedirectToAction("Index", "Carrier");
            }

            return RedirectToAction("Create", "User");
        }

        public ActionResult NewUser()
        {
            return RedirectToAction("Create", "User");
        }

    }
}