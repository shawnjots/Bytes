using Bytes.DAL;
using Bytes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Bytes.Controllers
{
    public class CategoryController : Controller
    {

        public ActionResult GetAllCategories()
        {
            CategoryDAL catDAL = new CategoryDAL();
            ModelState.Clear();
            return View(catDAL.GetAllCategories());
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category catModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoryDAL catDAL = new CategoryDAL();
                   if (catDAL.AddCategory(catModel))
                    {
                        ViewBag.Message = "Successfully added new category";
                    }
                }
                return RedirectToAction("GetAllCategories");
            }
            catch
            {

                return View();
            }
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryDAL catDAL = new CategoryDAL();

            return View(catDAL.GetAllCategories().Find(CategoryItem => CategoryItem.CategoryID == id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(int id, Category obj)
        {
            try
            {
                CategoryDAL catDAL = new CategoryDAL();
                catDAL.UpdateCategory(obj);
                return RedirectToAction("GetAllCategories");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteCategory(int id)
        {
            try
            {
                CategoryDAL catDAL = new CategoryDAL();
                if (catDAL.DeleteCategory(id))
                {
                    ViewBag.AlertMsg = "Category successfully deleted";
                }
                return RedirectToAction("GetAllCategories");
            }
            catch 
            {

                return View();
            }
            
        }
 
    }
}
