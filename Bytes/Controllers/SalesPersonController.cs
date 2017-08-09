using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytes.Controllers
{
    public class SalesPersonController : Controller
    {
        // GET: SalesPerson
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalesPerson/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalesPerson/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesPerson/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesPerson/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalesPerson/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalesPerson/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalesPerson/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
