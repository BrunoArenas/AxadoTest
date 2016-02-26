using Axado.DAO;
using Axado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axado.Controllers
{
    public class CarrierController : Controller
    {
        private CarrierDAO dao;
        public CarrierController(CarrierDAO dao)
        {
            this.dao = dao;
        }
        // GET: Carrier
        public ActionResult Index()
        {
            return View(dao.List());
        }

        // GET: Carrier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carrier/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Carrier/Create
        [HttpPost]
        public ActionResult Create(Carrier carrier)
        {
            try
            {
                dao.Create(carrier);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Carrier/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrier/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Carrier carrier)
        {
            try
            {
                dao.Update(id, carrier);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                dao.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
