using Bytes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bytes.Controllers
{
    public class ManagerController : Controller
    {
        public ActionResult GetAllManagers()
        {
            ManagerDAL manDAL = new ManagerDAL();
            ModelState.Clear();
            return View(manDAL.GetAllManagers());
        }

        [HttpGet]
        public ActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddManager(Manager manModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ManagerDAL manDAL = new ManagerDAL();
                    if (manDAL.AddManager(manModel))
                    {
                        ViewBag.Message = "Successfully added new Manager";
                    }
                }
                return View();
            }
            catch
            {

                return View();
            }
        }

        public ActionResult UpdateManager(int id)
        {
            ManagerDAL manDAL = new ManagerDAL();

            return View(manDAL.GetAllManagers().Find(ManagerItem => ManagerItem.EmployeeID == id));
        }

        [HttpPost]
        public ActionResult UpdateManager(int id, Manager obj)
        {
            try
            {
                ManagerDAL manDAL = new ManagerDAL();
                manDAL.UpdateManager(obj);
                return RedirectToAction("GetAllManagers");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteManager(int id)
        {
            try
            {
                ManagerDAL manDAL = new ManagerDAL();
                if (manDAL.DeleteManager(id))
                {
                    ViewBag.AlertMsg = "Manager successfully deleted";
                }
                return RedirectToAction("GetAllManagers");
            }
            catch
            {

                return View();
            }

        }

    }
}

