using Bytes.DAL;
using Bytes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytes.Controllers
{
    public class SalesPersonController : Controller
    {
        public ActionResult GetAllSalesPerson()
        {
            SalesPersonDAL salesDAL = new SalesPersonDAL();
            ModelState.Clear();
            return View(salesDAL.GetAllSalesPerson());
        }

        [HttpGet]
        public ActionResult AddSalesPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSalesPerson(SalesPerson salesModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SalesPersonDAL salesDAL = new SalesPersonDAL();
                    if (salesDAL.AddSalesPerson(salesModel))
                    {
                        ViewBag.Message = "Successfully added new Sales Person";
                    }
                }
                return View();
            }
            catch
            {

                return View();
            }
        }

        public ActionResult UpdateSalesPerson(int id)
        {
            SalesPersonDAL salesDAL = new SalesPersonDAL();

            return View(salesDAL.GetAllSalesPerson().Find(SalesPersonItem => SalesPersonItem.EmployeeID == id));
        }

        [HttpPost]
        public ActionResult UpdateSalesPerson(int id, SalesPerson obj)
        {
            try
            {
                SalesPersonDAL salesDAL = new SalesPersonDAL();
                salesDAL.UpdateSalesPerson(obj);
                return RedirectToAction("GetAllSalesPerson");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteSalesPErson(int id)
        {
            try
            {
                SalesPersonDAL salesDAL = new SalesPersonDAL();
                if (salesDAL.DeleteSalesPerson(id))
                {
                    ViewBag.AlertMsg = "Sales Person successfully deleted";
                }
                return RedirectToAction("GetAllSalesPErson");
            }
            catch
            {

                return View();
            }
        }
    }
}
